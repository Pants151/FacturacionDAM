using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmBrowFacrec : Form
    {
        private Tabla _tablaProveedores;
        private BindingSource _bsProveedores;

        private Tabla _tablaFacturas;
        private BindingSource _bsFacturas;

        private YearManager _year;

        private int _idProveedorSeleccionado = -1;

        #region Constructores
        public FrmBrowFacrec()
        {
            InitializeComponent();
            // Mismo rango de años que el original
            _year = new YearManager(DateTime.Now.Year, 2000, DateTime.Now.Year + 1);
        }
        #endregion

        #region Eventos del formulario

        /// <summary>
        /// Evento Load del formulario.
        /// </summary>
        private void FrmBrowFacrec_Load(object sender, EventArgs e)
        {
            if (!CargarProveedores())
            {
                MessageBox.Show(
                    "No se pudieron cargar los proveedores.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ajustamos los años disponibles en el combobox (Idéntico a facemi)
            tsComboYear.Items.Clear();
            tsComboYear.Items.AddRange(
                _year.GetYearList().Select(y => y.ToString()).ToArray()
            );

            int anho = Properties.Settings.Default.UltimoAnhoSeleccionado;
            if (anho != 0)
                _year.CurrentYear = anho;

            tsComboYear.SelectedItem = _year.CurrentYear.ToString();

            // Cargamos las facturas del año y proveedor seleccionado
            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void FrmBrowFacrec_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfiguracionVentana.Guardar(this, "BrowFacrec");
            Properties.Settings.Default.UltimoAnhoSeleccionado = _year.CurrentYear;
            Properties.Settings.Default.Save();
        }

        private void FrmBrowFacrec_Shown(object sender, EventArgs e)
        {
            ConfiguracionVentana.Restaurar(this, "BrowFacrec");
        }

        #endregion

        #region Eventos de controles

        private void tsComboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsComboYear.SelectedItem == null)
                return;

            int newYear = int.Parse(tsComboYear.SelectedItem.ToString());
            _year.CurrentYear = newYear;

            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void dgProveedores_SelectionChanged(object sender, EventArgs e)
        {
            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void dgFacturas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tsBtnEdit_Click(sender, e);
        }

        #endregion

        #region Botones (CRUD)

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            if (_bsFacturas == null || _idProveedorSeleccionado == -1) return;

            _bsFacturas.AddNew();

            // Pasamos los 5 parámetros requeridos (igual que en Facemi)
            FrmFacrec frm = new FrmFacrec(_bsFacturas, _tablaFacturas,
                Program.appDAM.emisor.id,
                _idProveedorSeleccionado,
                _year.CurrentYear);

            frm.Text = "Nueva factura de compra";

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _tablaFacturas.Refrescar();
            }
            else
            {
                _bsFacturas.CancelEdit();
            }

            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (_bsFacturas.Current is DataRowView row)
            {
                // Obtenemos el ID de la factura seleccionada
                int idFacrec = Convert.ToInt32(row["id"]);

                // IMPORTANTE: Pasamos los 6 parámetros que el nuevo constructor espera:
                // 1. BindingSource, 2. Tabla, 3. ID Emisor, 4. ID Proveedor, 5. Año, 6. ID Factura
                FrmFacrec frm = new FrmFacrec(
                    _bsFacturas,
                    _tablaFacturas,
                    Program.appDAM.emisor.id,
                    _idProveedorSeleccionado,
                    _year.CurrentYear,
                    idFacrec
                );

                // Al pasarle el idFacrec (el sexto parámetro), el formulario 
                // ya pone automáticamente modoEdicion = true internamente.
                frm.Text = "Editar factura de compra";

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tablaFacturas.Refrescar();
                }

                // Recargamos el grid para ver cambios
                CargarFacturasProveedorYAnyo(_year.CurrentYear);

                // Reposicionamos el cursor en la factura que estábamos editando
                int idx = _bsFacturas.Find("id", idFacrec);
                if (idx >= 0)
                    _bsFacturas.Position = idx;
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (!(_bsFacturas.Current is DataRowView row)) return;

            if (MessageBox.Show("¿Eliminar la factura de compra seleccionada?\nSe eliminarán también sus líneas.",
                "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes)
                return;

            int idFacrec = Convert.ToInt32(row["id"]);

            // Borrar factura recibida
            Tabla tFac = new Tabla(Program.appDAM.LaConexion);
            tFac.EjecutarComando("DELETE FROM facrec WHERE id=@id",
                new() { { "@id", idFacrec } });

            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void tsBtnFirst_Click(object sender, EventArgs e) => _bsFacturas.MoveFirst();
        private void tsBtnPrev_Click(object sender, EventArgs e) => _bsFacturas.MovePrevious();
        private void tsBtnNext_Click(object sender, EventArgs e) => _bsFacturas.MoveNext();
        private void tsBtnLast_Click(object sender, EventArgs e) => _bsFacturas.MoveLast();

        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarCSV((DataTable)_bsFacturas.DataSource, sfd.FileName);
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarXML((DataTable)_bsFacturas.DataSource, sfd.FileName, "Facturas Recibidas");
        }

        #endregion

        #region Métodos Privados

        private void ActualizarEstado()
        {
            tsLbNumReg.Text = $"Nº de registros: {_bsFacturas.Count}";
        }

        private bool CargarProveedores()
        {
            string mSql = "SELECT id, nifcif, nombrecomercial FROM proveedores ORDER BY nombrecomercial";
            _tablaProveedores = new Tabla(Program.appDAM.LaConexion);

            if (_tablaProveedores.InicializarDatos(mSql))
            {
                try
                {
                    _bsProveedores = new BindingSource { DataSource = _tablaProveedores.LaTabla };
                    dgProveedores.DataSource = _bsProveedores; // En el designer llámalo dgProveedores

                    dgProveedores.Columns["id"].Visible = false;
                    dgProveedores.Columns["nifcif"].HeaderText = "NIF/CIF";
                    dgProveedores.Columns["nifcif"].Width = 100;
                    dgProveedores.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
                    dgProveedores.Columns["nombrecomercial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgProveedores.MultiSelect = false;

                    // Estilo idéntico a Facemi
                    dgProveedores.EnableHeadersVisualStyles = false;
                    dgProveedores.ColumnHeadersHeight = 34;
                    dgProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240, 240);
                    dgProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 33, 33, 33);
                    dgProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    dgProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 255, 255);
                    return true;
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("Facrec cargar proveedores", ex.Message);
                    return false;
                }
            }
            return false;
        }

        private void CargarFacturasProveedorYAnyo(int aAnho)
        {
            if (!(_bsProveedores.Current is DataRowView prov))
            {
                dgFacturas.DataSource = null;
                tsLbNumReg.Text = "Facturas: 0";
                lbHeadFacrec.Text = "FACTURAS RECIBIDAS";
                return;
            }

            _idProveedorSeleccionado = Convert.ToInt32(prov["id"]);

            // Consulta adaptada a la tabla facrec y campo idempresa
            string mSql = $@"
                SELECT * FROM facrec
                WHERE idproveedor = {_idProveedorSeleccionado} AND idempresa = {Program.appDAM.emisor.id}
                  AND YEAR(fecha) = {aAnho}
                ORDER BY fecha DESC, numero DESC";

            _tablaFacturas = new Tabla(Program.appDAM.LaConexion);

            if (_tablaFacturas.InicializarDatos(mSql))
            {
                try
                {
                    _bsFacturas = new BindingSource { DataSource = _tablaFacturas.LaTabla };
                    dgFacturas.DataSource = _bsFacturas;

                    // Ocultamos columnas técnicas e internas
                    string[] ocultar = { "id", "idempresa", "idproveedor", "idconceptofac", "aplicaret", "notas", "tiporet" };
                    foreach (string col in ocultar) if (dgFacturas.Columns.Contains(col)) dgFacturas.Columns[col].Visible = false;

                    // Formateo visual idéntico
                    dgFacturas.Columns["numero"].HeaderText = "Nº";
                    dgFacturas.Columns["numero"].Width = 100; // En compras el número suele ser más largo
                    dgFacturas.Columns["fecha"].HeaderText = "Fecha";
                    dgFacturas.Columns["fecha"].Width = 105;
                    dgFacturas.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgFacturas.Columns["descripcion"].HeaderText = "Descripción";
                    dgFacturas.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    string[] importes = { "base", "cuota", "total", "retencion" };
                    foreach (string col in importes)
                    {
                        dgFacturas.Columns[col].Width = 85;
                        dgFacturas.Columns[col].DefaultCellStyle.Format = "N2";
                        dgFacturas.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgFacturas.Columns[col].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
                    }

                    dgFacturas.Columns["pagada"].HeaderText = "¿Pagada?";
                    dgFacturas.Columns["pagada"].Width = 75;
                    dgFacturas.Columns["pagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgFacturas.MultiSelect = false;

                    // Estilo de cabecera
                    dgFacturas.EnableHeadersVisualStyles = false;
                    dgFacturas.ColumnHeadersHeight = 34;
                    dgFacturas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240, 240);
                    dgFacturas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 33, 33, 33);
                    dgFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    dgFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 255, 255);

                    string nombreProv = prov["nombrecomercial"].ToString();
                    lbHeadFacrec.Text = $"Facturas de '{nombreProv}', en el año {_year.CurrentYear}";
                    tsLbNumReg.Text = $"Facturas: {_bsFacturas.Count}";
                    ActualizarTotalAnual(aAnho);
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("Cargando Facturas recibidas", ex.Message);
                }
            }
        }

        private void ActualizarTotalAnual(int aAnho)
        {
            decimal totalAnual = 0;
            string mSql = $@"SELECT SUM(total) FROM facrec 
                            WHERE idempresa = {Program.appDAM.emisor.id} 
                            AND YEAR(fecha) = {aAnho}";

            Tabla tTmp = new Tabla(Program.appDAM.LaConexion);
            if (tTmp.InicializarDatos(mSql))
            {
                if (tTmp.LaTabla.Rows.Count > 0 && tTmp.LaTabla.Rows[0][0] != DBNull.Value)
                    totalAnual = Convert.ToDecimal(tTmp.LaTabla.Rows[0][0]);
            }
            tTmp.Liberar();

            tsLbTotalAnual.Text = $" | Total Compras del año {aAnho}: {totalAnual:N2} €";
        }

        #endregion
    }
}
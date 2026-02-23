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
    public partial class FrmFacrec : Form
    {
        private BindingSource _bsFactura;
        private BindingSource _bsLineasFactura;
        private Tabla _tablaFactura;
        private Tabla _tablaLineasFactura;
        private Tabla _tablaConceptos;

        private int _idEmisor = -1;
        private int _idProveedor = -1;
        private int _anhoFactura = -1;

        public int idFactura = -1;
        public bool modoEdicion = false;

        #region Constructores

        public FrmFacrec()
        {
            InitializeComponent();
            InitFactura();
        }

        public FrmFacrec(BindingSource aBs, Tabla aTabla, int aIdEmisor, int aIdProveedor, int aYear, int aIdFactura = -1)
        {
            InitializeComponent();

            _idProveedor = aIdProveedor;
            _idEmisor = aIdEmisor;
            _anhoFactura = aYear;
            idFactura = aIdFactura;
            modoEdicion = (aIdFactura != -1);

            _bsFactura = aBs;
            _tablaFactura = aTabla;

            InitFactura();
        }

        #endregion

        #region Eventos del formulario

        private void FrmFacrec_Load(object sender, EventArgs e)
        {
            try
            {
                if (!CargarConceptos() || !CargarDatosEmisorYProveedor())
                    return;

                if (modoEdicion)
                    CargarLineasFacturaExistente();
                else
                    CrearLineasFacturaNueva();

                PrepararBindingFactura();
                PrepararBindingLineas();

                RecalcularTotales();
                ActualizarEstado();

                // Suscripción a eventos para cambios en tiempo real
                chkRetencion.CheckedChanged += (s, ev) => RecalcularTotales();
                numTipoRet.ValueChanged += (s, ev) => RecalcularTotales();
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Error Load FrmFacrec", ex.Message);
                MessageBox.Show("Se ha producido un error al inicializar la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmFacrec_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && _bsFactura != null)
            {
                fechaFactura.DataBindings.Clear();
                _bsFactura.CancelEdit();
            }
        }

        #endregion

        #region Botones

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            bool mCrearNuevaLinea = false;
            if (!modoEdicion)
            {
                if (MessageBox.Show("No ha guardado la nueva factura.\n¿Guardar antes de crear la línea?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    mCrearNuevaLinea = GuardarFactura();
            }
            else mCrearNuevaLinea = true;

            if (mCrearNuevaLinea)
            {
                _bsLineasFactura.AddNew();
                FrmLineaFacrec frm = new FrmLineaFacrec(_bsLineasFactura, _tablaLineasFactura, idFactura);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _bsLineasFactura.ResetBindings(false);
                    ActualizarEstado();
                    RecalcularTotales();
                }
                else _bsLineasFactura.CancelEdit();
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (_bsLineasFactura.Current is DataRowView)
            {
                FrmLineaFacrec frm = new FrmLineaFacrec(_bsLineasFactura, _tablaLineasFactura, idFactura, true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _bsLineasFactura.ResetBindings(false);
                    ActualizarEstado();
                    RecalcularTotales();
                }
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (!(_bsLineasFactura.Current is DataRowView)) return;
            if (MessageBox.Show("¿Eliminar línea?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _bsLineasFactura.RemoveCurrent();
                _tablaLineasFactura.GuardarCambios();
                ActualizarEstado();
                RecalcularTotales();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (GuardarFactura())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            if (_bsLineasFactura == null || _bsLineasFactura.Count == 0)
            {
                MessageBox.Show("No hay líneas en esta factura para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = $"Lineas_Factura_{txtNumero.Text}.csv"; // Nombre sugerido

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportarDatos.ExportarCSV((DataTable)_bsLineasFactura.DataSource, sfd.FileName);
            }
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            if (_bsLineasFactura == null || _bsLineasFactura.Count == 0)
            {
                MessageBox.Show("No hay líneas en esta factura para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            sfd.FileName = $"Lineas_Factura_{txtNumero.Text}.xml"; // Nombre sugerido

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportarDatos.ExportarXML((DataTable)_bsLineasFactura.DataSource, sfd.FileName, "LineasFactura");
            }
        }

        #endregion

        #region Métodos privados

        private void ActualizarEstado() => tsLbNumReg.Text = $"Nº de registros: {_bsLineasFactura.Count}";

        private bool GuardarFactura()
        {
            try
            {
                RecalcularTotales();

                // Comprobamos que los datos sean válidos antes de enviar a la BD
                if (!ValidarDatos()) return false;

                ForzarValoresNoNulos();
                _bsFactura.EndEdit();

                // Guardamos la cabecera de la factura en BD (si es nueva, hace INSERT)
                _tablaFactura.GuardarCambios();

                if (!modoEdicion)
                {
                    // Recuperamos el ID autogenerado para esta factura
                    using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", Program.appDAM.LaConexion))
                    {
                        idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    modoEdicion = true; // Pasamos a modo edición

                    if (_bsFactura.Current is DataRowView row)
                    {
                        row["id"] = idFactura;

                        // Consolidamos el cambio de ID para evitar el Concurrency Violation en el próximo guardado
                        row.Row.AcceptChanges();
                    }

                    // Recargamos el enlace de las líneas apuntando al nuevo idFactura
                    CargarLineasFacturaExistente();
                }

                // Guardamos las líneas si hay alguna
                if (_bsLineasFactura.Count > 0)
                {
                    _tablaLineasFactura.GuardarCambios();
                }

                return true;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Error Guardar Factura Recibida", ex.Message);
                MessageBox.Show("Error al guardar la factura: " + ex.Message);
                return false;
            }
        }

        private bool CargarDatosEmisorYProveedor()
        {
            lbNifcifEmisor.Text = Program.appDAM.emisor.nifcif;
            lbNombreEmisor.Text = Program.appDAM.emisor.nombreComercial;

            Tabla tProv = new Tabla(Program.appDAM.LaConexion);
            if (tProv.InicializarDatos($"SELECT id, nifcif, nombrecomercial FROM proveedores WHERE id = {_idProveedor}"))
            {
                lbNifcifProveedor.Text = tProv.LaTabla.Rows[0]["nifcif"].ToString();
                lbNombreProveedor.Text = tProv.LaTabla.Rows[0]["nombrecomercial"].ToString();

                if (!modoEdicion && _bsFactura.Current is DataRowView row)
                {
                    row["idempresa"] = _idEmisor;
                    row["idproveedor"] = _idProveedor;
                }
                return true;
            }
            return false;
        }

        private bool CargarConceptos()
        {
            if (_tablaConceptos.InicializarDatos("SELECT id, descripcion FROM conceptosfac ORDER BY descripcion"))
            {
                cbConceptFac.DataSource = _tablaConceptos.LaTabla;
                cbConceptFac.DisplayMember = "descripcion";
                cbConceptFac.ValueMember = "id";
                return true;
            }
            return false;
        }

        private void InitFactura()
        {
            _tablaLineasFactura = new Tabla(Program.appDAM.LaConexion);
            _tablaConceptos = new Tabla(Program.appDAM.LaConexion);
            _bsLineasFactura = new BindingSource();
        }

        private void CargarLineasFacturaExistente()
        {
            if (_tablaLineasFactura.InicializarDatos($"SELECT * FROM facrelin WHERE idfacrec = {idFactura}"))
                _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
        }

        private void CrearLineasFacturaNueva()
        {
            if (_tablaLineasFactura.InicializarDatos($"SELECT * FROM facrelin WHERE id = -1"))
                _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
        }

        private void PrepararBindingFactura()
        {
            if (_bsFactura.Current is DataRowView row && row["fecha"] == DBNull.Value)
                row["fecha"] = new DateTime(_anhoFactura, DateTime.Today.Month, DateTime.Today.Day);

            txtNumero.DataBindings.Add("Text", _bsFactura, "numero", true, DataSourceUpdateMode.OnPropertyChanged, "");
            fechaFactura.DataBindings.Add("Value", _bsFactura, "fecha", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
            cbConceptFac.DataBindings.Add("SelectedValue", _bsFactura, "idconceptofac", true, DataSourceUpdateMode.OnPropertyChanged, -1);
            txtDescripcion.DataBindings.Add("Text", _bsFactura, "descripcion", true, DataSourceUpdateMode.OnPropertyChanged, "");
            chkPagada.DataBindings.Add("Checked", _bsFactura, "pagada", true, DataSourceUpdateMode.OnPropertyChanged, false);
            chkRetencion.DataBindings.Add("Checked", _bsFactura, "aplicaret", true, DataSourceUpdateMode.OnPropertyChanged, false);
            numTipoRet.DataBindings.Add("Value", _bsFactura, "tiporet", true, DataSourceUpdateMode.OnPropertyChanged, 0m);

            txtNotas.DataBindings.Add("Text", _bsFactura, "notas");

            lbBase.DataBindings.Add("Text", _bsFactura, "base", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbCuota.DataBindings.Add("Text", _bsFactura, "cuota", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbTotal.DataBindings.Add("Text", _bsFactura, "total", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbRetencion.DataBindings.Add("Text", _bsFactura, "retencion", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
        }

        private void PrepararBindingLineas()
        {
            dgLineasFactura.DataSource = _bsLineasFactura;
            if (dgLineasFactura.Columns.Count > 0)
            {
                if (dgLineasFactura.Columns.Contains("id")) dgLineasFactura.Columns["id"].Visible = false;
                if (dgLineasFactura.Columns.Contains("idfacrec")) dgLineasFactura.Columns["idfacrec"].Visible = false;
                dgLineasFactura.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void RecalcularTotales()
        {
            if (_tablaLineasFactura?.LaTabla == null || _bsFactura.Current == null) return;

            // 1. Forzamos que los cambios en el Check y el Numeric se guarden en la fila AHORA.
            // Si no hacemos esto, al llamar a ResetCurrentItem más abajo, se perdería el check
            // que acabas de marcar porque leería el valor antiguo (false) de la fila.
            chkRetencion.DataBindings["Checked"]?.WriteValue();
            numTipoRet.DataBindings["Value"]?.WriteValue();

            decimal baseSum = 0, cuotaSum = 0;

            foreach (DataRow fila in _tablaLineasFactura.LaTabla.Rows)
            {
                // Solo sumamos filas que no estén borradas
                if (fila.RowState != DataRowState.Deleted)
                {
                    // Usamos Field<decimal> o Convert para asegurar el tipo
                    baseSum += fila.Field<decimal>("base");
                    cuotaSum += fila.Field<decimal>("cuota");
                }
            }

            // Calculamos totales usando los valores que acabamos de forzar (o los de la UI)
            decimal tRet = chkRetencion.Checked ? numTipoRet.Value : 0;
            decimal ret = Math.Round(baseSum * tRet / 100, 2);

            // 2. Actualizamos la fila en memoria
            DataRowView row = (DataRowView)_bsFactura.Current;
            row["base"] = baseSum;
            row["cuota"] = cuotaSum;
            row["retencion"] = ret;
            row["total"] = baseSum + cuotaSum - ret;

            // 3. ¡Importante! Avisamos a todos los controles (incluidos los Labels de totales)
            // de que los datos de la fila han cambiado y deben repintarse.
            _bsFactura.ResetCurrentItem();
        }

        private void ForzarValoresNoNulos()
        {
            if (_bsFactura.Current is DataRowView row)
            {
                // Evitamos que campos obligatorios viajen como DBNull
                if (row["descripcion"] == DBNull.Value) row["descripcion"] = txtDescripcion.Text;
                if (row["numero"] == DBNull.Value) row["numero"] = txtNumero.Text;

                if (row["tiporet"] == DBNull.Value) row["tiporet"] = numTipoRet.Value;
                if (row["aplicaret"] == DBNull.Value) row["aplicaret"] = chkRetencion.Checked ? 1 : 0;
                if (row["pagada"] == DBNull.Value) row["pagada"] = chkPagada.Checked ? 1 : 0;

                // Campos numéricos de totales
                if (row["base"] == DBNull.Value) row["base"] = 0m;
                if (row["cuota"] == DBNull.Value) row["cuota"] = 0m;
                if (row["total"] == DBNull.Value) row["total"] = 0m;
                if (row["retencion"] == DBNull.Value) row["retencion"] = 0m;
            }
        }

        private bool ValidarDatos()
        {
            if (!(_bsFactura.Current is DataRowView row))
                return false;

            // ============================
            // Validación de campos obligatorios
            // ============================

            // Número
            if (row["numero"] == DBNull.Value || string.IsNullOrWhiteSpace(row["numero"].ToString()))
            {
                MessageBox.Show("El campo 'Número' es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return false;
            }

            // Fecha
            if (row["fecha"] == DBNull.Value)
            {
                MessageBox.Show("El campo 'Fecha' es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechaFactura.Focus();
                return false;
            }

            // Concepto de facturación
            if (row["idconceptofac"] == DBNull.Value || Convert.ToInt32(row["idconceptofac"]) <= 0)
            {
                MessageBox.Show("Debe seleccionar un concepto de facturación.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbConceptFac.Focus();
                return false;
            }

            // Descripción
            if (row["descripcion"] == DBNull.Value || string.IsNullOrWhiteSpace(row["descripcion"].ToString()))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            // ============================
            // Fecha dentro del año seleccionado
            // ============================

            DateTime fecha = Convert.ToDateTime(row["fecha"]);
            DateTime inicio = new DateTime(_anhoFactura, 1, 1);
            DateTime fin = new DateTime(_anhoFactura, 12, 31);

            if (fecha < inicio || fecha > fin)
            {
                MessageBox.Show(
                    $"La fecha debe estar entre el {inicio:dd/MM/yyyy} y el {fin:dd/MM/yyyy}.",
                    "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                fechaFactura.Focus();
                return false;
            }

            // ============================
            // Comprobar duplicados PARA EL MISMO PROVEEDOR
            // ============================

            int numero = Convert.ToInt32(txtNumero.Text);
            int idActual = modoEdicion ? idFactura : -1;

            // Permitimos que diferentes proveedores tengan el mismo número de factura en el mismo año.
            string sqlCheck = $@"SELECT COUNT(*) FROM facrec 
                    WHERE idempresa = {Program.appDAM.emisor.id} 
                    AND idproveedor = {_idProveedor}
                    AND numero = {numero} 
                    AND YEAR(fecha) = {fechaFactura.Value.Year} 
                    AND id <> {idActual}";

            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlCheck, Program.appDAM.LaConexion))
            {
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    MessageBox.Show($"El número de factura {numero} ya existe PARA ESTE PROVEEDOR en el año {fechaFactura.Value.Year}.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumero.Focus();
                    return false;
                }
            }

            // ============================
            // Todo correcto
            // ============================

            return true;
        }

        #endregion

        private void chkRetencion_CheckedChanged(object sender, EventArgs e) => RecalcularTotales();
        private void numTipoRet_ValueChanged(object sender, EventArgs e) => RecalcularTotales();

        private void dgLineasFactura_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tsBtnEdit_Click(sender, e);
        }
    }
}
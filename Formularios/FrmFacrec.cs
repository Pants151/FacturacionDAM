using FacturacionDAM.Modelos;
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

        #endregion

        #region Métodos privados

        private void ActualizarEstado() => tsLbNumReg.Text = $"Nº de registros: {_bsLineasFactura.Count}";

        private bool GuardarFactura()
        {
            try
            {
                RecalcularTotales();

                // 1. VALIDACIÓN: Ahora comprobamos que la descripción no esté vacía antes de enviar a la BD
                if (!ValidarDatos()) return false;

                ForzarValoresNoNulos();
                _bsFactura.EndEdit();

                // Guardamos la cabecera
                _tablaFactura.GuardarCambios();

                if (!modoEdicion)
                {
                    // Recuperamos el ID generado para las líneas
                    using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", Program.appDAM.LaConexion))
                    {
                        idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    modoEdicion = true;
                }

                // 2. IMPORTANTE: Solo intentamos guardar líneas si hay alguna
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
            decimal baseSum = 0, cuotaSum = 0;
            foreach (DataRow fila in _tablaLineasFactura.LaTabla.Rows)
            {
                if (fila.RowState != DataRowState.Deleted)
                {
                    baseSum += Convert.ToDecimal(fila["base"]);
                    cuotaSum += Convert.ToDecimal(fila["cuota"]);
                }
            }
            decimal tRet = chkRetencion.Checked ? numTipoRet.Value : 0;
            decimal ret = Math.Round(baseSum * tRet / 100, 2);
            DataRowView row = (DataRowView)_bsFactura.Current;
            row["base"] = baseSum; row["cuota"] = cuotaSum; row["retencion"] = ret; row["total"] = baseSum + cuotaSum - ret;
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
            // Comprobamos los campos que MySQL exige (NOT NULL) [Turn Context: facrec table]
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("El número de factura es obligatorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return false;
            }

            if (cbConceptFac.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un concepto de facturación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbConceptFac.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción de la factura es obligatoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        #endregion

        private void chkRetencion_CheckedChanged(object sender, EventArgs e) => RecalcularTotales();
        private void numTipoRet_ValueChanged(object sender, EventArgs e) => RecalcularTotales();
    }
}
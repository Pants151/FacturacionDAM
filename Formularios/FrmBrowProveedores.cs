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
    public partial class FrmBrowProveedores : Form
    {
        private Tabla _tabla;                                     // Tabla a gestionar
        private BindingSource _bs = new BindingSource();          // BindingSource para comunicar con controles.
        private Dictionary<int, string> _provincias;              // Diccionario para la búsqueda de provincias.

        /// <summary>
        /// Constructor.
        /// </summary>
        public FrmBrowProveedores()
        {
            InitializeComponent();
            _provincias = new Dictionary<int, string>();
        }


        /*********** MOVIMIENTO POR LOS REGISTROS DEL DATAGRIDVIEW ***************/

        private void tsBtnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();

        private void tsBtnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();

        private void tsBtnNext_Click(object sender, EventArgs e) => _bs.MoveNext();

        private void tsBtnLast_Click(object sender, EventArgs e) => _bs.MoveLast();


        /****************** EVENTOS CRUD DE LA TABLA *********************/

        /// <summary>
        /// Evento "Click" sobre el botón de nuevo registro.
        /// </summary>
        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew();
            // Cambiado a FrmProveedor
            FrmProveedor frm = new FrmProveedor(_bs, _tabla);
            frm.edicion = false;
            frm.Text = "Nuevo proveedor";
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _tabla.Refrescar();
                ActualizarEstado();
            }
            else
            {
                _bs.CancelEdit();
            }
        }

        /// <summary>
        /// Evento "Click" sobre el botón de edición.
        /// </summary>
        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                // Cambiado a FrmProveedor
                FrmProveedor frm = new FrmProveedor(_bs, _tabla);
                frm.edicion = true;
                frm.Text = "Editar proveedor";
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tabla.Refrescar();
                    ActualizarEstado();
                }
            }
        }

        /// <summary>
        /// Evento "doble click" sobre del DataGridView. Realiza la misma acción que el botón de edición.
        /// </summary>
        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tsBtnEdit_Click(sender, e);
        }

        /// <summary>
        /// Evento "Click" del Botón eliminar
        /// </summary>
        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                int idProveedor = Convert.ToInt32(row["id"]);

                // Verificamos si tiene facturas recibidas (facrec) antes de borrar
                if (TieneFacturasRecibidas(idProveedor))
                {
                    MessageBox.Show("No se puede eliminar el proveedor porque tiene facturas de compra registradas.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Desea eliminar el proveedor seleccionado?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _bs.RemoveCurrent();
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
            }
        }

        /// <summary>
        /// Formatea la columna de provincias.
        /// </summary>
        private void dgTabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgTabla.Columns[e.ColumnIndex].Name == "idprovincia")
            {
                if (e.Value is int idProvincia)
                {
                    e.Value = ObtenerNombreProvincia(idProvincia);
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Evento "Load" del formulario.
        /// </summary>
        private void FrmBrowProveedores_Load(object sender, EventArgs e)
        {
            _tabla = new Tabla(Program.appDAM.LaConexion);
            string mSql = "SELECT * FROM proveedores ORDER BY nombrecomercial";

            // Suscribirse al evento para que se ejecute CUANDO LOS DATOS ESTÉN LISTOS
            dgTabla.DataBindingComplete += (s, args) => PersonalizarDataGrid();

            if (_tabla.InicializarDatos(mSql))
            {
                dgTabla.AutoGenerateColumns = true;
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                CargarProvincias();
            }
            ActualizarEstado();
        }

        /// <summary>
        /// Guarda el estado de la ventana.
        /// </summary>
        private void FrmBrowProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfiguracionVentana.Guardar(this, "BrowProveedores");
        }


        /// <summary>
        /// Restaura el estado de la ventana.
        /// </summary>
        private void FrmBrowProveedores_Shown(object sender, EventArgs e)
        {
            ConfiguracionVentana.Restaurar(this, "BrowProveedores");
        }


        /// <summary>
        /// Exportación a CSV.
        /// </summary>
        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarCSV((DataTable)_bs.DataSource, sfd.FileName);
        }

        /// <summary>
        /// Exportación a XML.
        /// </summary>
        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarXML((DataTable)_bs.DataSource, sfd.FileName, "Proveedores");
        }

        /************************* MÉTODO PRIVADOS ******************************/

        private void ActualizarEstado()
        {
            tsLbNumReg.Text = $"Nº de proveedores: {_bs.Count}";
        }

        /// <summary>
        /// Personaliza las columnas para la tabla proveedores.
        /// </summary>
        private void PersonalizarDataGrid()
        {
            dgTabla.Columns["id"].Visible = false;
            dgTabla.Columns["telefono2"].Visible = false;
            dgTabla.Columns["domicilio"].Visible = false;
            dgTabla.Columns["nifcif"].HeaderText = "NIF/CIF";
            dgTabla.Columns["nifcif"].Width = 100;
            dgTabla.Columns["nombre"].HeaderText = "Nombre";
            dgTabla.Columns["nombre"].Width = 120;
            dgTabla.Columns["apellidos"].HeaderText = "Apellidos";
            dgTabla.Columns["apellidos"].Width = 160;
            dgTabla.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
            dgTabla.Columns["nombrecomercial"].Width = 200;
            dgTabla.Columns["codigopostal"].HeaderText = "C.P.";
            dgTabla.Columns["codigopostal"].Width = 75;
            dgTabla.Columns["idprovincia"].HeaderText = "Provincia";
            dgTabla.Columns["idprovincia"].Width = 150;
            dgTabla.Columns["telefono1"].HeaderText = "Teléfono 1";
            dgTabla.Columns["telefono1"].Width = 100;
            dgTabla.Columns["email"].HeaderText = "Correo electrónico";
            dgTabla.Columns["email"].Width = 250;

            // Estilo para la cabecera:
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.ColumnHeadersHeight = 34;
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240, 240);
            dgTabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 33, 33, 33);
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Colorear filas alternas
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 255, 255);
        }

        private void CargarProvincias()
        {
            // Nota: nombreProvincia con P mayúscula según SQL
            using var cmd = new MySqlCommand("SELECT id, nombreProvincia FROM provincias", Program.appDAM.LaConexion);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                _provincias[reader.GetInt32(0)] = reader.GetString(1);
            }
        }

        private string ObtenerNombreProvincia(int id)
        {
            return _provincias.TryGetValue(id, out var nombre) ? nombre : "";
        }

        /// <summary>
        /// Comprueba si el proveedor tiene facturas recibidas vinculadas.
        /// </summary>
        private bool TieneFacturasRecibidas(int idProveedor)
        {
            string sql = "SELECT COUNT(*) FROM facrec WHERE idproveedor = @id";
            using var cmd = new MySqlCommand(sql, Program.appDAM.LaConexion);
            cmd.Parameters.AddWithValue("@id", idProveedor);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}
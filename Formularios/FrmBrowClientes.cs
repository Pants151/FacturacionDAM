using FacturacionDAM.Modelos;
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
    public partial class FrmBrowClientes : Form
    {
        private Tabla _tabla; // Tabla a gestionar
        private BindingSource _bs; // Para comunicación con los controles visuales
        private Dictionary<int, string> _provincias; // Lista de provincias
        public FrmBrowClientes()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appDAM.LaConexion);
            _bs = new BindingSource();
            CargarProvincias();
        }

        private void FrmBrowClientes_Load(object sender, EventArgs e)
        {
            // Comprobamos que haya un emisor seleccionado
            if (Program.appDAM.emisor == null)
            {
                MessageBox.Show("Debe seleccionar un emisor primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // La consulta SQL ahora filtra por idemisor
            string sql = $"SELECT * FROM clientes WHERE idemisor = {Program.appDAM.emisor.id}";

            if (_tabla.InicializarDatos(sql)) // Usamos la nueva SQL
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                PersonalizarDataGrid(); // Revisa esta función
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los clientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarEstado();
            }
        }

        /********* METODOS PRIVADOS ***********/

        // Guarda el estado de la ventana (posición y tamaño)
        public void GuardarEstadoVentana()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.BrowClientesSize = this.Size;
                Properties.Settings.Default.BrowClientesLocation = this.Location;
            }

            //Guardar el estado de la ventana como string: "Normal|Maximized|Minimized"
            Properties.Settings.Default.BrowClientesState = this.WindowState.ToString();
            Properties.Settings.Default.Save();

        }

        // Restaura el estado de la ventana (posición y tamaño)
        public void RestaurarEstadoVentana()
        {
            string estado = Properties.Settings.Default.BrowEmisoresState;
            switch (estado)
            {
                case "Maximized":
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case "Minimized":
                    this.WindowState = FormWindowState.Minimized;
                    break;
                default:
                    this.WindowState = FormWindowState.Normal;
                    break;
            }

            if (Properties.Settings.Default.BrowEmisoresState == "Normal")
            {
                this.Size = Properties.Settings.Default.BrowEmisoresSize;
                this.Location = Properties.Settings.Default.BrowEmisoresLocation;
            }

        }

        //Personaliza las columnas del DataGridView
        private void PersonalizarDataGrid()
        {
            // Ocultar columnas no necesarias
            dgTabla.Columns["id"].Visible = false;
            dgTabla.Columns["domicilio"].Visible = false;
            dgTabla.Columns["telefono2"].Visible = false;
            dgTabla.Columns["descripcion"].Visible = false;

            // Cambiar los textos de las cabeceras
            dgTabla.Columns["nifcif"].HeaderText = "NIF/CIF";
            dgTabla.Columns["nombrecomercial"].HeaderText = "Razón Social";
            dgTabla.Columns["nombre"].HeaderText = "Nombre";
            dgTabla.Columns["apellido"].HeaderText = "Apellidos";
            dgTabla.Columns["domicilio"].HeaderText = "Domicilio";
            dgTabla.Columns["codigopostal"].HeaderText = "Código Postal";
            dgTabla.Columns["poblacion"].HeaderText = "Población";
            dgTabla.Columns["idprovincia"].HeaderText = "Provincia";
            dgTabla.Columns["telefono1"].HeaderText = "Teléfono 1";
            dgTabla.Columns["telefono2"].HeaderText = "Teléfono 2";
            dgTabla.Columns["email"].HeaderText = "Email";
            dgTabla.Columns["descripcion"].HeaderText = "Descripción";

            // Ajuste manual de anchuras
            dgTabla.Columns["nifcif"].Width = 100;
            dgTabla.Columns["nombrecomercial"].Width = 200;
            dgTabla.Columns["nombre"].Width = 120;
            dgTabla.Columns["apellido"].Width = 160;
            dgTabla.Columns["codigopostal"].Width = 75;
            dgTabla.Columns["poblacion"].Width = 150;
            dgTabla.Columns["idprovincia"].Width = 150;
            dgTabla.Columns["telefono1"].Width = 100;
            dgTabla.Columns["email"].Width = 250;

            // Colorear filas alternas
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 255, 255);

            // Estilo para cabeceras (Color, fuente y altura)
            DataGridViewCellStyle estiloCabecera = new DataGridViewCellStyle
            {
                BackColor = Color.LightBlue,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                WrapMode = DataGridViewTriState.True
            };


        }

        private string ObtenerNombreProvincia(int idProvincia)
        {
            return _provincias.TryGetValue(idProvincia, out string nombre) ? nombre : "Desconocida";

        }

        private void ActualizarEstado()
        {
            tslbStatus.Text = $"Nº de registros: {_bs.Count}";
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (_bs?.DataSource == null || _tabla?.LaTabla == null)
            {
                MessageBox.Show("No hay datos cargados. Imposible crear un nuevo emisor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bs.AddNew();
            // --- INICIO MODIFICACIÓN ---
            // Asignamos el idemisor actual a la nueva fila
            if (_bs.Current is DataRowView row)
            {
                row["idemisor"] = Program.appDAM.emisor.id;
            }
            // --- FIN MODIFICACIÓN ---

            using (FrmCliente frm = new FrmCliente(_bs, _tabla)) // <-- Llama a FrmCliente
            {
                frm.edicion = false; // Es creación, no edición
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
                else
                {
                    _bs.CancelEdit();
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();


        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();



        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();


        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                FrmEmisor frm = new FrmEmisor(_bs, _tabla);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tabla.Refrescar();
                    ActualizarEstado();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                // Ya no necesitamos la comprobación del emisor en uso
                if (MessageBox.Show("¿Está seguro de que desea eliminar el cliente seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _bs.RemoveCurrent();
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
            }
        }

        private bool esEmisorSeleccionado(string aNifCif)
        {
            if (Program.appDAM.emisor != null && Program.appDAM.emisor.nifcif == aNifCif)
            {
                return true;
            }
            return false;
        }

        private bool TieneFacturasEmitidas(int emisorId)
        {
            using var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM FACTURAS WHERE EMISOR_ID = @EmisorId", Program.appDAM.LaConexion);
            cmd.Parameters.AddWithValue("@EmisorId", emisorId);
            var count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private bool TieneFacturasRecibidas(string aNifCif)
        {
            return false;
        }

        // Cargar la lista de provincias desde la base de datos
        private void CargarProvincias()
        {
            _provincias = new Dictionary<int, string>();
            using var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT id, nombreprovincia FROM provincias", Program.appDAM.LaConexion);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                _provincias[id] = nombre;
            }
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                // Cambiamos FrmEmisor por FrmCliente
                using (FrmCliente frm = new FrmCliente(_bs, _tabla)) // <-- Llama a FrmCliente
                {
                    frm.edicion = true; // Es edición
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        _tabla.GuardarCambios(); // Guardar cambios al editar
                        ActualizarEstado();
                    }
                    else
                    {
                        _bs.CancelEdit(); // Descartar cambios si cancela
                    }
                }
            }
        }

        // Formatear la celda de provincia para mostrar el nombre en lugar del ID
        private void dgTabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgTabla.Columns[e.ColumnIndex].Name == "idprovincia" && e.Value != null)
            {
                if (e.Value is int idProvincia)
                {
                    e.Value = ObtenerNombreProvincia(idProvincia);
                    e.FormattingApplied = true;
                }
            }
        }

        // Manejar el evento de cierre del formulario
        private void FrmBrowEmisores_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarEstadoVentana();
        }

        private void FrmBrowEmisores_Shown(object sender, EventArgs e)
        {
            RestaurarEstadoVentana();
        }

        // Exportar a CSV
        private void Export_A_CSV(string rutaArchivo)
        {
            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                List<string> lineas = new List<string>();

                //Cabezera
                var cabecera = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                lineas.Add(string.Join(";", cabecera));

                //Filas de datos
                foreach (DataRow row in dt.Rows)
                {
                    var campos = row.ItemArray.Select(field => field?.ToString()?.Replace(";", ","));
                    lineas.Add(string.Join(";", campos));
                }

                File.WriteAllLines(rutaArchivo, lineas, Encoding.UTF8);
                MessageBox.Show("Exportación a CSV completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //Program.appDAM.RegistrarLog($"Error al exportar a CSV: {ex.Message}");
                MessageBox.Show($"Error al exportar a CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exportar a XML
        private void Export_A_XML(string rutaArchivo)
        {

            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                dt.TableName = "Clientes";
                dt.WriteXml(rutaArchivo, XmlWriteMode.WriteSchema);
                MessageBox.Show("Exportación a XML completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //Program.appDAM.RegistrarLog($"Error al exportar a XML: {ex.Message}");
                MessageBox.Show($"Error al exportar a XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_A_CSV(sfd.FileName);
            }
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_A_XML(sfd.FileName);
            }
        }
    }
}

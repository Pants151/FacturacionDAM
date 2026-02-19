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
using System.Text.RegularExpressions;

namespace FacturacionDAM.Formularios
{
    public partial class FrmProveedor : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        public bool edicion;

        public FrmProveedor(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            _bs.EndEdit();            // Finaliza edición del registro actual
            _tabla.GuardarCambios();  // Se propaga a la BD
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit(); // Cancela cambios si es nueva fila
            this.Close();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            // --- AJUSTE DE BINDINGS A LA TABLA 'proveedores' ---
            txtNifCif.DataBindings.Add("Text", _bs, "nifcif", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtNombre.DataBindings.Add("Text", _bs, "nombre", true, DataSourceUpdateMode.OnPropertyChanged, "");

            // En proveedores la columna es 'apellidos' (plural)
            txtApellidos.DataBindings.Add("Text", _bs, "apellidos", true, DataSourceUpdateMode.OnPropertyChanged, "");

            txtNombreComercial.DataBindings.Add("Text", _bs, "nombrecomercial", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtDomicilio.DataBindings.Add("Text", _bs, "domicilio", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtPob.DataBindings.Add("Text", _bs, "poblacion", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtCp.DataBindings.Add("Text", _bs, "codigopostal", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtTel1.DataBindings.Add("Text", _bs, "telefono1", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtTel2.DataBindings.Add("Text", _bs, "telefono2", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtEmail.DataBindings.Add("Text", _bs, "email", true, DataSourceUpdateMode.OnPropertyChanged, "");

            // Cargar provincias
            Tabla tablaProvincias = new Tabla(Program.appDAM.LaConexion);
            // El nombre exacto de la columna en tu SQL es 'nombreProvincia' (con P mayúscula)
            tablaProvincias.InicializarDatos("SELECT * FROM provincias ORDER BY nombreProvincia");
            cbProv.DataSource = tablaProvincias.LaTabla;
            cbProv.DisplayMember = "nombreProvincia";
            cbProv.ValueMember = "id";
            cbProv.DataBindings.Add("SelectedValue", _bs, "idprovincia", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
        }

        private bool ValidarDatos()
        {
            // NIF/CIF y nombrecomercial no pueden estar vacíos
            if (string.IsNullOrWhiteSpace(txtNifCif.Text))
            {
                MessageBox.Show("El campo NIF/CIF es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNifCif.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreComercial.Text))
            {
                MessageBox.Show("El campo Nombre Comercial es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreComercial.Focus();
                return false;
            }

            // Formato del NIF/CIF (Debe tener 9 caracteres alfanuméricos)
            string nifCif = txtNifCif.Text.Trim().ToUpper();
            if (!Regex.IsMatch(nifCif, @"^[A-Z0-9]{9}$"))
            {
                MessageBox.Show("El formato del NIF/CIF no es válido. Debe contener exactamente 9 caracteres (letras y números).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNifCif.Focus();
                return false;
            }

            // Validación de NIF duplicado en la tabla CORRECTA ('proveedores')
            if (NifDuplicado(nifCif))
            {
                MessageBox.Show("El NIF/CIF introducido ya pertenece a otro proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNifCif.Focus();
                return false;
            }

            // Código Postal (Opcional, pero si se pone deben ser 5 dígitos numéricos)
            string cp = txtCp.Text.Trim();
            if (!string.IsNullOrEmpty(cp) && !Regex.IsMatch(cp, @"^\d{5}$"))
            {
                MessageBox.Show("El Código Postal debe tener exactamente 5 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCp.Focus();
                return false;
            }

            // Teléfonos (Opcionales, pero si se ponen deben ser 9 dígitos)
            string tel1 = txtTel1.Text.Trim();
            if (!string.IsNullOrEmpty(tel1) && !Regex.IsMatch(tel1, @"^\d{9}$"))
            {
                MessageBox.Show("El Teléfono 1 debe tener exactamente 9 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTel1.Focus();
                return false;
            }

            string tel2 = txtTel2.Text.Trim();
            if (!string.IsNullOrEmpty(tel2) && !Regex.IsMatch(tel2, @"^\d{9}$"))
            {
                MessageBox.Show("El Teléfono 2 debe tener exactamente 9 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTel2.Focus();
                return false;
            }

            // Email válido si se ha introducido
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !Validaciones.EsEmailValido(email))
            {
                MessageBox.Show("El formato del email no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool NifDuplicado(string nifCif)
        {
            // Obtenemos el ID actual para excluirlo si estamos editando
            int? idActual = edicion ? (int?)((DataRowView)_bs.Current)["id"] : null;

            // IMPORTANTE: Cambiado de "clientes" a "proveedores"
            return !Validaciones.EsValorCampoUnico("proveedores", "nifcif", nifCif, idActual);
        }
    }
}
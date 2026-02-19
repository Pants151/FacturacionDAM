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
    public partial class FrmCliente : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        public bool edicion;


        public FrmCliente(BindingSource bs, Tabla tabla)
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


        private void FrmCliente_Load(object sender, EventArgs e)
        {
            txtNifCif.DataBindings.Add("Text", _bs, "nifcif");
            txtNombre.DataBindings.Add("Text", _bs, "nombre");
            txtApellidos.DataBindings.Add("Text", _bs, "apellido");
            txtNombreComercial.DataBindings.Add("Text", _bs, "nombrecomercial");
            txtDomicilio.DataBindings.Add("Text", _bs, "domicilio");
            txtPob.DataBindings.Add("Text", _bs, "poblacion");
            txtCp.DataBindings.Add("Text", _bs, "codigopostal");
            txtTel1.DataBindings.Add("Text", _bs, "telefono1");
            txtTel2.DataBindings.Add("Text", _bs, "telefono2");
            txtEmail.DataBindings.Add("Text", _bs, "email");
            
            // Cargar provincias en el ComboBox
            Tabla tablaProvincias = new Tabla(Program.appDAM.LaConexion);
            tablaProvincias.InicializarDatos("SELECT * FROM provincias");
            cbProv.DataSource = tablaProvincias.LaTabla;
            cbProv.DisplayMember = "nombreprovincia";
            cbProv.ValueMember = "id";
            cbProv.DataBindings.Add("SelectedValue", _bs, "idprovincia");
        }

        private bool ValidarDatos()
        {
            // NIF/CIF y nombre comercial no pueden estar vacíos
            if (string.IsNullOrWhiteSpace(txtNifCif.Text))
            {
                MessageBox.Show("El campo NIF/CIF no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNifCif.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreComercial.Text))
            {
                MessageBox.Show("El campo Nombre Comercial no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // NIF/CIF duplicado en la base de datos
            if (this.NifDuplicado(nifCif))
            {
                MessageBox.Show("El NIF/CIF introducido ya existe en otro registro de clientes.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Si ha llegado aquí, ha pasado absolutamente todas las pruebas de seguridad
            return true;
        }

        /// <summary>
        /// Verifica si el nif/cif pasado como parámetro ya existe en la tabla. Si estamos
        /// en modo edición, busca en todos los registros que no coincida con el actual.
        /// </summary>
        /// <param name="nifCif">El nif/cif a verificar.</param>
        /// <returns>Retorna true si existe, false sino.</returns>
        private bool NifDuplicado(string nifCif)
        {
            if (edicion && _bs.Current is DataRowView row && row["id"] is int id)
                return !Validaciones.EsValorCampoUnico("clientes", "nifcif", txtNifCif.Text.Trim(), id);

            return !Validaciones.EsValorCampoUnico("clientes", "nifcif", txtNifCif.Text.Trim());
        }


    }
}

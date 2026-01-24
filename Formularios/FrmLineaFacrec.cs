using FacturacionDAM.Modelos;
using System;
using System.Data;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmLineaFacrec : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;
        private Tabla _tablaProductos;
        private BindingSource _bsProductos = new BindingSource();

        private int _idFactura;
        private bool _modoEdicion;

        public FrmLineaFacrec(BindingSource aBs, Tabla aTabla, int aIdFactura, bool aModoEdicion = false)
        {
            InitializeComponent();
            _bs = aBs;
            _tabla = aTabla;
            _idFactura = aIdFactura;
            _modoEdicion = aModoEdicion;
        }

        private void FrmLineaFacrec_Load(object sender, EventArgs e)
        {
            // 1. Configurar límites de los controles numéricos (sobreescribe los del Designer)
            numCantidad.Maximum = 999999;
            numPrecio.Maximum = 999999;
            numTipoIva.Maximum = 100;

            // 2. Cargar buscador de productos
            CargarProductos();

            // 3. Inicializar valores si es línea nueva
            if (!_modoEdicion)
            {
                DataRowView row = (DataRowView)_bs.Current;
                row["idfacrec"] = _idFactura; // FK a la tabla de compras
                row["cantidad"] = 1.00m;
                row["precio"] = 0.00m;
                row["tipoiva"] = 21.00m;
                row["base"] = 0.00m;
                row["cuota"] = 0.00m;
                row["descripcion"] = "";
            }

            // 4. Vincular controles
            PrepararBindings();

            // Suscribir eventos de cambio en los controles numéricos
            numCantidad.ValueChanged += (s, ev) => RecalcularLinea();
            numPrecio.ValueChanged += (s, ev) => RecalcularLinea();
            numTipoIva.ValueChanged += (s, ev) => RecalcularLinea();

            // Si quieres que responda también al escribir:
            numCantidad.KeyUp += (s, ev) => RecalcularLinea();
            numPrecio.KeyUp += (s, ev) => RecalcularLinea();

            RecalcularLinea();
        }

        private void PrepararBindings()
        {
            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion", true, DataSourceUpdateMode.OnPropertyChanged);
            numCantidad.DataBindings.Add("Value", _bs, "cantidad", true, DataSourceUpdateMode.OnPropertyChanged);
            numPrecio.DataBindings.Add("Value", _bs, "precio", true, DataSourceUpdateMode.OnPropertyChanged);
            numTipoIva.DataBindings.Add("Value", _bs, "tipoiva", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void RecalcularLinea()
        {
            if (_bs.Current == null) return;

            decimal cant = numCantidad.Value;
            decimal precio = numPrecio.Value;
            decimal iva = numTipoIva.Value;

            decimal baseLin = Math.Round(cant * precio, 2);
            decimal cuotaLin = Math.Round(baseLin * (iva / 100), 2);
            decimal totalLin = baseLin + cuotaLin;

            // Actualizamos visualmente el panel de la línea
            lbBase.Text = baseLin.ToString("N2") + " €";
            lbCuota.Text = cuotaLin.ToString("N2") + " €"; // IMPORTANTE: Antes lbIva, ahora lbCuota
            lbTotal.Text = totalLin.ToString("N2") + " €";

            // Muy importante: Actualizamos el DataRow vinculado para que los cambios se guarden
            DataRowView row = (DataRowView)_bs.Current;
            row["base"] = baseLin;
            row["cuota"] = cuotaLin;
        }

        private void CargarProductos()
        {
            _tablaProductos = new Tabla(Program.appDAM.LaConexion);
            string sql = "SELECT p.id, p.descripcion, p.preciounidad, t.porcentaje " +
                         "FROM productos p LEFT JOIN tiposiva t ON p.idtipoiva = t.id ORDER BY p.descripcion";

            if (_tablaProductos.InicializarDatos(sql))
            {
                _bsProductos.DataSource = _tablaProductos.LaTabla;
                cbProducto.DataSource = _bsProductos;
                cbProducto.DisplayMember = "descripcion";
                cbProducto.ValueMember = "id";
                cbProducto.SelectedIndex = -1;
            }
        }

        // IMPORTANTE: Antes btnTrasladar_Click, ahora BtnProducto_Click
        private void BtnProducto_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedItem == null) return;
            DataRowView prod = (DataRowView)_bsProductos.Current;

            txtDescripcion.Text = prod["descripcion"].ToString();
            numPrecio.Value = Convert.ToDecimal(prod["preciounidad"]);
            if (prod["porcentaje"] != DBNull.Value)
                numTipoIva.Value = Convert.ToDecimal(prod["porcentaje"]);

            RecalcularLinea();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción de la línea es obligatoria.");
                return;
            }
            _bs.EndEdit();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
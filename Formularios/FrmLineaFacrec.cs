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
            // 1. Configurar límites de los controles numéricos (evita errores de desbordamiento)
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

            // 5. Suscribir eventos para recalcular al cambiar valores
            numCantidad.ValueChanged += (s, ev) => RecalcularLinea();
            numPrecio.ValueChanged += (s, ev) => RecalcularLinea();
            numTipoIva.ValueChanged += (s, ev) => RecalcularLinea();

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
            DataRowView row = (DataRowView)_bs.Current;

            decimal cantidad = numCantidad.Value;
            decimal precio = numPrecio.Value;
            decimal tipoIva = numTipoIva.Value;

            decimal baseImp = Math.Round(cantidad * precio, 2);
            decimal cuotaIva = Math.Round(baseImp * (tipoIva / 100m), 2);

            // Guardar en el DataRow
            row["base"] = baseImp;
            row["cuota"] = cuotaIva;

            // Actualizar etiquetas visuales
            lbBase.Text = baseImp.ToString("N2") + " €";
            lbIva.Text = cuotaIva.ToString("N2") + " €";
            lbTotal.Text = (baseImp + cuotaIva).ToString("N2") + " €";
        }

        private void CargarProductos()
        {
            _tablaProductos = new Tabla(Program.appDAM.LaConexion);
            // Traemos el % de IVA desde la tabla tiposiva unida a productos
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

        private void btnTrasladar_Click(object sender, EventArgs e)
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
            _bs.EndEdit(); // Esto confirma los cambios en la memoria local
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
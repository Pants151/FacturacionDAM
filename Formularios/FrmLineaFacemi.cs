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
    public partial class FrmLineaFacemi : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        private Tabla _tablaProductos;
        private BindingSource _bsProductos;

        private int _idFactura = -1;
        private bool _modoEdicion = false;

        public FrmLineaFacemi()
        {
            InitializeComponent();
        }

        public FrmLineaFacemi(BindingSource aBs, Tabla aTabla, int aIdFactura, bool aModoEdicion = false)
        {
            InitializeComponent();
            _tabla = aTabla;
            _bs = aBs;
            _idFactura = aIdFactura;
            _modoEdicion = aModoEdicion;
        }

        private void FrmLineaFacemi_Load(object sender, EventArgs e)
        {
            CargarProductos();
            PrepararBindings();
            SeleccionarProductoSiEdicion();
            InitLineaFactura();
            RecalcularLinea();

            // Suscribir eventos de cambio en los controles numéricos
            numCantidad.ValueChanged += (s, ev) => RecalcularLinea();
            numPrecio.ValueChanged += (s, ev) => RecalcularLinea();
            numTipoIva.ValueChanged += (s, ev) => RecalcularLinea();

            // Si quieres que responda también al escribir (no solo a las flechitas):
            numCantidad.KeyUp += (s, ev) => RecalcularLinea();
            numPrecio.KeyUp += (s, ev) => RecalcularLinea();
        }

        // Inicializa los valores de la línea de factura
        private void InitLineaFactura()
        {
            if (!(_bs.Current is DataRowView row)) return;
            if (row["idfacemi"] == DBNull.Value) row["idfacemi"] = _idFactura;
            if (row["cantidad"] == DBNull.Value) row["cantidad"] = 1m;
            if (row["precio"] == DBNull.Value) row["precio"] = 0m;
            if (row["base"] == DBNull.Value) row["base"] = 0m;
            if (row["cuota"] == DBNull.Value) row["cuota"] = 0m;
            if (row["descripcion"] == DBNull.Value) row["descripcion"] = "";
            if (row["tipoiva"] == DBNull.Value) row["tipoiva"] = 0m;

        }

        // Selecciona el producto en el combo si estamos en modo edición
        private void SeleccionarProductoSiEdicion()
        {
            if (!_modoEdicion) return;
            if (!(_bs.Current is DataRowView row)) return;
            if (row["idproducto"] == DBNull.Value) return;

            int idProducto = Convert.ToInt32(row["idproducto"]);
            cbProducto.SelectedValue = idProducto;
        }

        #region Métodos propios

        /// <summary>
        /// Asocia controles con las fuentes de datos
        /// </summary>
        private void PrepararBindings()
        {
            if (!(_bs.Current is DataRowView row))
            {
                MessageBox.Show("Error al preparar los bindings de la línea de factura.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // Relación con la factura
            row["idfacemi"] = _idFactura;

            // Bindings principales
            cbProducto.DataBindings.Add("SelectedValue", _bs, "idproducto", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);

            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion", true, DataSourceUpdateMode.OnPropertyChanged, "");

            numPrecio.DataBindings.Add("Value", _bs, "precio", true, DataSourceUpdateMode.OnPropertyChanged, 0m);

            numTipoIva.DataBindings.Add("Value", _bs, "tipoiva", true, DataSourceUpdateMode.OnPropertyChanged, 0m);

            numCantidad.DataBindings.Add("Value", _bs, "cantidad", true, DataSourceUpdateMode.OnPropertyChanged, 0m);


        }

        /// <summary>
        /// Calcula base, cuota y totales, en función de los datos del formulario.
        /// </summary>
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
            lbCuota.Text = cuotaLin.ToString("N2") + " €";
            lbTotal.Text = totalLin.ToString("N2") + " €";

            // Muy importante: Actualizamos el DataRow vinculado para que los cambios se guarden
            DataRowView row = (DataRowView)_bs.Current;
            row["base"] = baseLin;
            row["cuota"] = cuotaLin;
        }

        /// <summary>
        /// Carga los productos en el formulario de productos.
        /// </summary>
        private void CargarProductos()
        {
            _tablaProductos = new Tabla(Program.appDAM.LaConexion);

            // Sentencia SQL select
            string mSql = @"SELECT p.id, p.descripcion, p.preciounidad, p.activo as producto_activo,
                            t.porcentaje as iva_porcentaje, t.activo as iva_activo from productos p
                            left join tiposiva t on t.id = p.idtipoiva order by p.descripcion";

            if (!_tablaProductos.InicializarDatos(mSql))
            {
                MessageBox.Show("No se pudieron cargar los productos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            _bsProductos = new BindingSource
            {
                DataSource = _tablaProductos.LaTabla
            };

            cbProducto.DataSource = _bsProductos;
            cbProducto.DisplayMember = "descripcion";
            cbProducto.ValueMember = "id";
            cbProducto.SelectedIndex = -1;
        }
        #endregion

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            TrasladarDatosProducto();
        }

        // Transfiere los datos del producto seleccionado a la línea de factura
        private void TrasladarDatosProducto()
        {
            if (!(_bsProductos.Current is DataRowView row)) return;

            // Precio
            numPrecio.Value = Convert.ToDecimal(row["preciounidad"]);

            // Tipo de IVA
            numTipoIva.Value = Convert.ToDecimal(row["iva_porcentaje"]);

            // Descripción
            txtDescripcion.Text = row["descripcion"].ToString();

            RecalcularLinea();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ForzarNoNulosLinea();
            RecalcularLinea();

            if (!ValidarLinea()) return;

            _bs.EndEdit();
            _tabla.GuardarCambios();
            DialogResult = DialogResult.OK;
            Close();
        }

        // Valida que la línea de factura tenga los datos mínimos necesarios
        private bool ValidarLinea()
        {
             if (!(_bs.Current is DataRowView row)) return false;

            RecalcularLinea();

            // Si la descripción está vacía
            if (row["descripcion"] == DBNull.Value || string.IsNullOrWhiteSpace(row["descripcion"].ToString()))
            {
                MessageBox.Show("La descripción de la línea no puede estar vacía.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            // Si la cantidad es menor o igual que cero
            if (numCantidad.Value <= 0m)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return false;
            }

            // Si el precio es negativo
            if (numPrecio.Value < 0m)
            {
                MessageBox.Show("El precio no puede ser negativo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrecio.Focus();
                return false;
            }

            // Si el tipo de IVA es negativo
            if (numTipoIva.Value < 0m)
            {
                MessageBox.Show("El tipo de IVA no puede ser negativo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numTipoIva.Focus();
                return false;
            }

            // Si el tipo de IVA es mayor que 100
            if (numTipoIva.Value > 100m)
            {
                MessageBox.Show("El tipo de IVA no puede ser mayor que 100.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numTipoIva.Focus();
                return false;
            }

            // Si no se ha seleccionado un producto válido
            if (cbProducto.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Debe seleccionar un producto válido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProducto.Focus();
                return false;
            }

            // Si el producto no está activo y no estamos en modo edición
            if (_bsProductos.Current is DataRowView prodRow)
            {
                bool productoActivo = Convert.ToBoolean(prodRow["producto_activo"]);
                if (!productoActivo && !_modoEdicion)
                {
                    MessageBox.Show("El producto seleccionado no está activo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Si todo es correcto
            return true;
        }
            

        // Valida que la línea de factura tenga los datos mínimos necesarios
        private void ForzarNoNulosLinea()
        {
            if (!(_bs.Current is DataRowView row)) return;

            if (row["cantidad"] == DBNull.Value) row["cantidad"] = numCantidad.Value;
            if (row["precio"] == DBNull.Value) row["precio"] = numPrecio.Value;
            if (row["tipoiva"] == DBNull.Value) row["tipoiva"] = numTipoIva.Value;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

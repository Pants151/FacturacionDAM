using FacturacionDAM.Modelos;
using System.Xml.Linq;

namespace FacturacionDAM.Formularios
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /******** EVENTOS DEL FORMULARIO Y CONTROLES *********/

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Program.appDAM.conectado)
                Program.appDAM.DesconectarDB();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
#if !DEBUG
                // Si no estamos en compilación DEBUG, ocultamos el menú de depuración
                tsMenuItemDepura.Visible = false;
#endif
            menuMain.MdiWindowListItem = ventanasToolStripMenuItem;
            SeleccionarEmisor();
            RefreshControles();
        }

        private void tsBtnConfig_Click(object sender, EventArgs e)
        {
            // Si hay ventanas abiertas que NO sean la propia configuración
            if (this.MdiChildren.Any(f => f is not FrmConfig))
            {
                var res = MessageBox.Show("Para entrar en configuración se deben cerrar todas las ventanas abiertas. ¿Desea continuar?",
                                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    CerrarFormulariosHijos();
                }
                else
                {
                    return; // El usuario cancela la entrada a configuración
                }
            }

            AbrirFormularioHijo<FrmConfig>();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            this.Close();
        }

        private void tsMenuItemDepura_Click(object sender, EventArgs e)
        {
#if DEBUG
            AbrirFormularioHijo<FrmDepuracion>();
#endif

        }

        private void tsBtnEmisores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowEmisores>();
        }

        private void tsBtnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowClientes>();
        }

        private void conceptosDeFacturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowConceptosFac>();
        }


        private void tiposDeIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowTiposIva>();
        }


        private void productosYServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowProductos>();
        }

        private void tsBtnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowProveedores>();
        }

        private void tsBtnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowFacrec>();
        }


        private void tsBtnVentas_Click(object sender, EventArgs e)
        {
            if (!Program.appDAM.HayClientes())
                MessageBox.Show(
                    "No hay clientes registrados.\nDebe registrar al menos un cliente antes de gestionar facturas.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
                AbrirFormularioHijo<FrmBrowFacemi>();
        }

        private void tsItemMenuSeleccionarEmisor_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            SeleccionarEmisor();
            RefreshControles();
        }


        /// <summary>
        /// Evento que ordena las ventanas Mdi hijas en cascada.
        /// </summary>
        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Evento que ordena en mosaico horizontal las ventanas Mdi hijas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);

        }

        /// <summary>
        /// Evento que ordena en mosaico vertical las ventanas Mdi hijas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cerrarTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
        }


        /*************** MÉTODOS PRIVADOS *******************/

        public void SeleccionarEmisor()
        {
            if ((Program.appDAM.estadoApp == EstadoApp.ConectadoSinEmisor) ||
                 (Program.appDAM.estadoApp == EstadoApp.Conectado))
            {
                using (var frm = new FrmSeleccionarEmisor())
                {
                    var resultado = frm.ShowDialog();

                    Program.appDAM.estadoApp =
                        (Program.appDAM.emisor == null) ? EstadoApp.ConectadoSinEmisor : EstadoApp.Conectado;

                }
            }
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
                //if (frm is not FrmDepuracion)
                frm.Close();
        }


        /// <summary>
        /// Abre un formulario hijo MDI del tipo indicado. 
        /// Si ya existe, lo activa y lo restaura si estaba minimizado.
        /// </summary>
        private void AbrirFormularioHijo<T>() where T : Form, new()
        {
            // Si intentamos abrir algo que NO es configuración, pero la configuración SÍ está abierta...
            if (typeof(T) != typeof(FrmConfig) && this.MdiChildren.Any(f => f is FrmConfig))
            {
                MessageBox.Show("Debe cerrar la ventana de configuración antes de abrir otra sección.",
                                "Configuración en curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [Tu código actual de búsqueda y apertura...]
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is T)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.Activate();
                    return;
                }
            }

            T nuevoFrm = new T();
            nuevoFrm.MdiParent = this;
            nuevoFrm.WindowState = FormWindowState.Maximized;
            nuevoFrm.Show();
        }


        // 2. Actualiza el refresco para incluir el menú superior
        private void RefreshToolBar()
        {
            bool conectadoFull = (Program.appDAM.estadoApp == EstadoApp.Conectado);
            bool conectadoParcial = (Program.appDAM.estadoApp == EstadoApp.ConectadoSinEmisor);

            // BOTONES LATERALES
            tsBtnEmisores.Enabled = conectadoFull || conectadoParcial;
            tsBtnClientes.Enabled = conectadoFull;
            tsBtnProveedores.Enabled = conectadoFull;
            tsBtnVentas.Enabled = conectadoFull;
            tsBtnCompras.Enabled = conectadoFull;

            // SECCIÓN DE FACTURACIÓN DEL MENUSTRIP
            // (Asegúrate de que este nombre coincide con el de tu Property Name en el diseño)
            facturaciónToolStripMenuItem.Enabled = conectadoFull;
        }

        private void RefreshStatusBar()
        {
            if (Program.appDAM.emisor == null)
                tsLbEmisor.Text = "Sin emisor seleccionado";
            else
                tsLbEmisor.Text = $"{Program.appDAM.emisor.nombre} {Program.appDAM.emisor.apellidos};  NIF: {Program.appDAM.emisor.nifcif}";

            switch (Program.appDAM.estadoApp)
            {
                case EstadoApp.Conectado:
                    tsLbEstado.Text = "Conectado a la base de datos";
                    break;
                case EstadoApp.SinConexion:
                    tsLbEstado.Text = "No se ha establecido la conexión a la base de datos.";
                    break;
                case EstadoApp.ConectadoSinEmisor:
                    tsLbEstado.Text = "Conectado a la base de datos, pero no se ha seleccionado un emisor.";
                    break;
                case EstadoApp.Error:
                    if (Program.appDAM.ultimoError != "")
                        tsLbEstado.Text = "Se ha producido un error, revisa el log para más detalles.";
                    else
                        tsLbEstado.Text = "Se ha producido un error";
                    break;
            }
        }

        /// <summary>
        /// Actualiza la barra de estado y la barra de botones izquierda.
        /// </summary>
        public void RefreshControles()
        {
            RefreshToolBar();
            RefreshStatusBar();
        }
    }
}

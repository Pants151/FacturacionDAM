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

        private void tsItemMenuSeleccionarEmisor_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            SeleccionarEmisor();
            RefreshControles();
        }


        /*************** MÉTODOS PRIVADOS *******************/

        private void SeleccionarEmisor()
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
            // Buscar si ya existe un formulario hijo de ese tipo
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is T)
                {
                    // Si estaba minimizado, lo restauramos
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.Activate();
                    return;
                }
            }

            // No estaba abierto: creamos una nueva instancia
            T nuevoFrm = new T();
            nuevoFrm.MdiParent = this;
            nuevoFrm.WindowState = FormWindowState.Maximized;
            nuevoFrm.Show();
        }


        private void RefreshToolBar()
        {
            // Esta es la lógica existente
            bool conectadoConEmisor = (Program.appDAM.estadoApp == EstadoApp.Conectado);
            bool conectadoSinEmisor = (Program.appDAM.estadoApp == EstadoApp.ConectadoSinEmisor);
            bool sinConexion = (Program.appDAM.estadoApp == EstadoApp.SinConexion);

            // Habilitar/Deshabilitar botones según el estado
            tsBtnConfig.Enabled = true; // Siempre habilitado
            tsBtnSalir.Enabled = true;  // Siempre habilitado

            tsBtnEmisores.Enabled = (conectadoConEmisor || conectadoSinEmisor); // Habilitado si hay conexión

            // Habilitar el resto solo si hay un emisor seleccionado
            tsBtnVentas.Enabled = conectadoConEmisor;
            tsBtnCompras.Enabled = conectadoConEmisor;
            tsBtnClientes.Enabled = conectadoConEmisor; // <-- Habilitar Clientes
            tsBtnProveedores.Enabled = conectadoConEmisor;
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

        private void RefreshControles()
        {
            RefreshToolBar();
            RefreshStatusBar();
        }

        private void tsBtnEmisores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowEmisores>();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cerrarTodasLasVentanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
        }

        private void tsBtnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowClientes>();
        }
    }
}

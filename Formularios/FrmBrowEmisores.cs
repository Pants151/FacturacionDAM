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
    public partial class FrmBrowEmisores : Form
    {
        private Tabla _tabla; // Tabla a gestionar
        private BindingSource _bs; // Para comunicación con los controles visuales
        public FrmBrowEmisores()
        {
            InitializeComponent();
            _bs = new BindingSource();
            _tabla = new Tabla(Program.appDAM.LaConexion);
        }

        private void FrmBrowEmisores_Load(object sender, EventArgs e)
        {
            if (_tabla.InicializarDatos("SELECT * FROM emisores"))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los emisores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarEstado();
            }
        }

        /********* METODOS PRIVADOS ***********/
        private void ActualizarEstado()
        {
            tslbStatus.Text = $"Nº de registros: {_bs.Count}";
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _bs.AddNew();
            /*FrmEmisor frm = new FrmEmisor();
            if (from.ShowDialog() == DialogResult.OK)
            {
                _tabla.Refrescar();
                ActualizarEstado();
            }*/
        }
        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();


        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();



        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();


        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                /*FrmEmisor frm = new FrmEmisor();
                  if (from.ShowDialog() == DialogResult.OK)
                  {
                      _tabla.Refrescar();
                      ActualizarEstado();
                  }*/
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar el emisor seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _bs.RemoveCurrent();
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
            }
        }
    }
}

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
    public partial class FrmEmisor : Form
    {
        public FrmEmisor()
        {
            InitializeComponent();
        }

        private void FrmEmisor_Load(object sender, EventArgs e)
        {
            txt_nifcif.DataBindings.Add("Text", _bs, "NIFCIF");
        }
    }
}

using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDAM.Modelos
{
    public class Emisor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string nifcif {  get; set; } 

        public string nombreComercial { get; set; }

        public int nextNumFac {  get; set; }

        public Emisor ()
        {
            id = -1;
        }

        internal void ActualizarEmisor(BindingSource bs)
        {
            DataRowView? fila = bs?.Current as DataRowView;

            Debug.Assert(fila != null, "El BindingSource no tiene una fila actual válida.");

            if (fila == null) return;

            if (Convert.ToInt32(fila["id"]) == this.id)
            {
                this.nombre = fila["nombre"].ToString();
                this.apellidos = fila["apellido"].ToString();
                this.nifcif = fila["nifcif"].ToString();
                this.nombreComercial = fila["nombrecomercial"].ToString();
                this.nextNumFac = Convert.ToInt32(fila["nextnumfac"]);
            }
        }
        
    }
}

using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace FacturacionDAM.Modelos
{
    public class Emisor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string nifcif { get; set; }
        public string nombreComercial { get; set; }
        public int nextNumFac { get; set; }

        public Emisor()
        {
            id = -1;
        }

        internal void ActualizarEmisor(BindingSource bs)
        {
            DataRowView? fila = bs?.Current as DataRowView;

            Debug.Assert(fila != null, "El BindingSource no tiene una fila actual válida.");

            if (fila == null) return;

            // Extraemos el ID protegiéndolo de los DBNull
            int filaId = fila["id"] != DBNull.Value ? Convert.ToInt32(fila["id"]) : -1;

            // Comprobamos si es nuestro emisor (o si es un emisor nuevo cuyo ID aún es -1)
            if (filaId == this.id || this.id == -1)
            {
                // Si nosotros éramos un emisor nuevo (-1) y la base de datos ya le dio un ID real, lo guardamos
                if (this.id == -1 && filaId != -1)
                {
                    this.id = filaId;
                }

                this.nombre = fila["nombre"] != DBNull.Value ? fila["nombre"].ToString() : "";
                this.apellidos = fila["apellido"] != DBNull.Value ? fila["apellido"].ToString() : "";
                this.nifcif = fila["nifcif"] != DBNull.Value ? fila["nifcif"].ToString() : "";
                this.nombreComercial = fila["nombrecomercial"] != DBNull.Value ? fila["nombrecomercial"].ToString() : "";

                // Extraemos el siguiente número de factura (Si está vacío en DBNull, le damos 1 por defecto)
                this.nextNumFac = fila["nextnumfac"] != DBNull.Value ? Convert.ToInt32(fila["nextnumfac"]) : 1;
            }
        }
    }
}
using FacturacionDAM.Modelos;
using Google.Protobuf.Reflection;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
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
    public partial class FrmInformFacemiAnual : Form
    {
        public FrmInformFacemiAnual()
        {
            InitializeComponent();
        }

        private void btn_informe_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM vista_facturas_emitidas
                           WHERE Emisor = " + Program.appDAM.emisor.id.ToString() +
                           " AND Fecha BETWEEN '" + fecha_inicio.Value.Date.ToString("yyyy-MM-dd") +
                            "' AND '" + fecha_final.Value.Date.ToString("yyyy-MM-dd") + "'";

            Tabla tabla = new Tabla(Program.appDAM.LaConexion);

            if (!tabla.InicializarDatos(sql))
            {
                MessageBox.Show("No se pudieron cargar los datos del informe.");
                return;
            }

            try
            {
            // Cargar e inicializar el reporte
                        StiReport reporte = new StiReport();
                        reporte.Load("Informes/InformeFacemiList1.mrt");

                        reporte.Dictionary.Databases.Clear();

                        var ds = new DataSet();
                        ds.Tables.Add(tabla.LaTabla.Copy());
                        ds.Tables[0].TableName = "vista_facturas_emitidas";

                        reporte.RegData(ds);

                        reporte.Dictionary.Synchronize();

                        // Asignar la banda a la fuente por código
                        StiDataBand dataBand = reporte.Pages[0].Components.OfType<StiDataBand>().FirstOrDefault();

                        if (dataBand != null)
                        {
                            dataBand.DataSourceName = "vista_facturas_emitidas";
                        }

                        // Modifico las variables del informe
                        reporte.Dictionary.Variables["nombre_emisor"].Value = Program.appDAM.emisor.nombreComercial;
                        reporte.Dictionary.Variables["rango_fechas"].Value = "desde " + fecha_inicio.Value.Date.ToString("dd/MM/yyyy") +
                                                                        " hasta " + fecha_final.Value.Date.ToString("dd/MM/yyyy");

                        // Mostrar el reporte
                        reporte.Show();
            } catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Cargando informe de facturas emitidas anual", ex.Message);
                MessageBox.Show("Error al cargar los datos del informe");
                return;
            }
            
        }
    }
}

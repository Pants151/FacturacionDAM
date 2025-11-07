namespace FacturacionDAM.Modelos
{
    // Puedes copiar Emisor.cs y renombrarlo
    public class Cliente
    {
        public int id { get; set; }
        public int idemisor { get; set; } // <-- Añadir esto
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string nifcif { get; set; }
        public string nombreComercial { get; set; }

        public Cliente()
        {
            id = -1;
            idemisor = -1;
        }
    }
}
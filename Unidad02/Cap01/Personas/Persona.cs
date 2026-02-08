namespace Personas
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Dni { get; set; }
        public int Edad { get; set; }

        private string _nombre;
        private string _apellido;
        private string _dni;
        private int _edad;

        public Persona(string nombre, string apellido, string dni, int edad)
        {
            _nombre = nombre;
            _apellido = apellido;
            _dni = dni;
            _edad = edad;            

        }

        public string GetFullName()
        {
            return _nombre + _apellido;
        }

        public int GetAge()
        {
            return _edad;
        }
        
    }
}

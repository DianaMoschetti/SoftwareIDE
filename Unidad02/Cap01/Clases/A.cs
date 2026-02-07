
namespace Clases
{
    public class A
    {
        public string? NombreInstancia { get; set; }

        private string? _nombre;

        public A()
        {
            //_nombre = NombreInstancia;
            _nombre = "Instancia sin nombre"; 
        }

        public A(string nombreInstancia)
        {
            _nombre = nombreInstancia;
        }

        /* Además, 1 método “MostrarNombre” que devuelva por consola el nombre de la instancia y otros tres métodos M1, M2 y M3
         * que muestren por consola un mensaje avisando que el metodo fue invocado.         
         */
        public void MostrarNombre()
        {
            System.Console.WriteLine($"Nombre de la instancia: {_nombre}");
        }

        public void M1()
        {
            System.Console.WriteLine("Método M1 invocado.");
        }

        public void M2()
        {
            System.Console.WriteLine("Método M2 invocado.");
        }

        public void M3()
        {
            System.Console.WriteLine("Método M3 invocado.");
        }
    }
}

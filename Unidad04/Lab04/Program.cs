using System.Text;

namespace Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Contactos contactos = new ContactosMySQL();
            contactos.Listar();
            Menu(contactos);
        }

        static void Menu(Contactos contactos)
        {
            string rta = "";
            do
            {
                Console.WriteLine("1. Listar contactos");
                Console.WriteLine("2. Nuevo contacto");
                Console.WriteLine("3. Editar contacto");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5. Guardar cambios");
                Console.WriteLine("6. Salir");
                rta = Console.ReadLine();
                switch (rta)
                {
                    case "1":
                        contactos.Listar();
                        break;
                    case "2":
                        contactos.NuevoContacto();
                        break;
                    case "3":
                        contactos.EditarContacto();
                        break;
                    case "4":
                        contactos.EliminarFila();
                        break;
                    case "5":
                        contactos.AplicaCambios();
                        break;
                }
            } while (rta != "6");

        }
    }
}
namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManejadorArchivo manejadorArchivo;
            Console.WriteLine("Seleccione el tipo de archivo:");
            Console.WriteLine("1. Archivo de texto");
            Console.WriteLine("2. Archivo XML");
            if (Console.ReadLine() == "1")
            {
                manejadorArchivo = new ManejadorArchivoTxt();
            }
            else
            {
                manejadorArchivo = new ManejadorArchivoXml();
            }

            manejadorArchivo.Listar();
            Menu(manejadorArchivo);
        }

        static void Menu(ManejadorArchivo manejadorArchivo)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Listar contactos");
            Console.WriteLine("2. Agregar contacto");
            Console.WriteLine("3. Modificar contacto");
            Console.WriteLine("4. Eliminar contacto");
            Console.WriteLine("5. Guardar cambios");
            Console.WriteLine("6. Salir");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    manejadorArchivo.Listar();
                    break;
                case "2":
                    manejadorArchivo.NuevaFila();
                    break;
                case "3":
                    manejadorArchivo.EditarFila();
                    break;
                case "4":
                    manejadorArchivo.EliminarFila();
                    break;
                case "5":
                    manejadorArchivo.AplicaCambios();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            Menu(manejadorArchivo);
        }
    }
}

    

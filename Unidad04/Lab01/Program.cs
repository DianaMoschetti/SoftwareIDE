using System.Data;
using System.Xml;

public class Program
{
    public static void Main(string[] args)
    {
        //Leer();        
        //Escribir();
        //Console.ReadKey();
        Console.WriteLine("Presione una tecla para generar el archivo agendaxml.xml con los datos de agenda txt");
        Console.ReadKey();
        EscribirXML();
        Console.WriteLine("Archivo generado. Presione una tecla para verlo");
        Console.ReadKey();
        Console.WriteLine();
        LeerXML();
        Console.ReadKey();
    }

    private static void Leer()
    {
        string linea;
        Console.WriteLine("Nombre\tApellido\tEMail\t\t\t\tTelefono");
        StreamReader lector = File.OpenText("agenda.txt");
        do
        {
            linea = lector.ReadLine();
            if (linea != null)
            {
                string[] valores = linea.Split(';');
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", valores[0], valores[1], valores[2], valores[3]);
            }
        } while (linea != null);

        lector.Close();
    }

    private static void Escribir()
    {
        StreamWriter escritor = File.AppendText("agenda.txt");
        Console.WriteLine("Ingrese nuevo contacto");
        string rta = "S";
        while (rta == "S")
        {
            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese el apellido:");
            string apellido = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese el email:");
            string email = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese el telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            escritor.WriteLine(nombre + ";" + apellido + ";" + email + ";" + telefono);

            Console.WriteLine("Desea ingresar otro contacto? (S/N)");
            rta = Console.ReadLine().ToUpper();
        }
        escritor.Close();
    }

    private static void EscribirXML() 
    {
        XmlTextWriter escritorXML = new XmlTextWriter("agendaxml.xml", null);
        escritorXML.Formatting = Formatting.Indented;
        escritorXML.WriteStartDocument(true);
        escritorXML.WriteStartElement("DocumentElement");
        StreamReader lector = File.OpenText("agenda.txt");
        string linea;
        do
        {
            linea =lector.ReadLine();
            if( linea != null)
            {
                string[] valores = linea.Split(';');
                escritorXML.WriteStartElement("contactos");
                escritorXML.WriteStartElement("nombre");
                escritorXML.WriteValue(valores[0]);
                escritorXML.WriteEndElement(); // cierro tag d enombre
                escritorXML.WriteStartElement("apellido");
                escritorXML.WriteValue(valores[1]);
                escritorXML.WriteEndElement();
                escritorXML.WriteStartElement("email");
                escritorXML.WriteValue(valores[2]);
                escritorXML.WriteEndElement();
                escritorXML.WriteStartElement("telefono");
                escritorXML.WriteValue(valores[3]);
                escritorXML.WriteEndElement(); // cierro tag de telefono
                escritorXML.WriteEndElement(); // cierro tag d econtactos

            }
        } while(linea  != null);
        escritorXML.WriteEndElement(); // cierro tag de DocumentElement
        escritorXML.WriteEndDocument();

        escritorXML.Close();
        lector.Close();
    }

    private static void LeerXML()
    {
        XmlTextReader lectorXML = new XmlTextReader("agendaxml.xml");
        string tagAnterior = "";
        while (lectorXML.Read()) 
        {
            if(lectorXML.NodeType == XmlNodeType.Element)
            {
                tagAnterior = lectorXML.Name;

            }
            else if (lectorXML.NodeType == XmlNodeType.Text)
            {
                Console.WriteLine(tagAnterior + ": " + lectorXML.Value);
            }
        }
        lectorXML.Close();
    }




}
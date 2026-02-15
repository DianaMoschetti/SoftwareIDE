using System.Data;

using Microsoft.Data.SqlClient;

namespace Ejercicio06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True; Encrypt=False";

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", connection);
            connection.Open();
            adapter.Fill(dtEmpresas);
            connection.Close();

            Console.WriteLine("Listado de empresas:");
            foreach (DataRow row in dtEmpresas.Rows)
            {
                Console.WriteLine($"CustomerID: {row["CustomerID"]}, CompanyName: {row["CompanyName"]}");
            }

            Console.WriteLine("Elija el CustomerID que desea modificar:");
            string custId = Console.ReadLine();

            DataRow[] rowsEmpresas = dtEmpresas.Select($"CustomerID = '{custId}'");
            if (rowsEmpresas.Length != 1)
            { 
                Console.WriteLine("No se encontró el CustomerID o hay más de uno.");
                Console.ReadLine();
                return;
            }
            else
            {
                DataRow rowEmpresa = rowsEmpresas[0];
                string nombreActual = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine($"El nombre actual de la empresa es: {nombreActual}");
                Console.WriteLine("Ingrese el nuevo nombre de la empresa:");
                string nuevoNombre = Console.ReadLine();

                //rowEmpresa["CompanyName"] = nuevoNombre;
                rowEmpresa.BeginEdit();
                rowEmpresa["CompanyName"] = nuevoNombre;
                rowEmpresa.EndEdit();

                //SqlCommand updateCommand = new SqlCommand("UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID", connection);
                SqlCommand updateCommand = new SqlCommand();
                updateCommand.Connection = connection;
                updateCommand.CommandText = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID";
                updateCommand.Parameters.AddWithValue("@CompanyName", nuevoNombre);
                updateCommand.Parameters.AddWithValue("@CustomerID", custId);

                adapter.UpdateCommand = updateCommand;
                //connection.Open(); --> NO HACE FALTA ABRIR LA CONEXIÓN, EL ADAPTER SE ENCARGA DE ABRIRLA Y CERRARLA CUANDO EJECUTA EL UPDATE
                adapter.Update(dtEmpresas);
                //connection.Close();

            }
        }
    }
}
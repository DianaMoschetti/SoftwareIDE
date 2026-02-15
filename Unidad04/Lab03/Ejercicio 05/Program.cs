using System.Data;

using Microsoft.Data.SqlClient;

namespace Ejercicio05
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

            Console.ReadLine();
        }
    }
}
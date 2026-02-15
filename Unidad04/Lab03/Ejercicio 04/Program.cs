using System.Data;

using Microsoft.Data.SqlClient;

namespace Ejercicio04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection connection = new SqlConnection();
            //SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True");
            connection.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True; Encrypt=False";
            SqlCommand comando = new SqlCommand("SELECT CustomerID, CompanyName FROM Customers", connection);
            //comando.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            //comando.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            connection.Open();
            SqlDataReader reader = comando.ExecuteReader();
            dtEmpresas.Load(reader);
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
//Server=(localdb)\\mssqllocaldb;Database=FootballLeagueDb;Trusted_Connection=True; Encrypt=False"
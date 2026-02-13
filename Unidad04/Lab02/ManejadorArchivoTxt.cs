using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class ManejadorArchivoTxt : ManejadorArchivo
    {
        protected string connectionString
        {
            get
            {
                //return @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Proyectos\Unidades\Unidad 04\Lab02\Lab02\bin\Debug;" +
                //    "Extended Properties='text;HDR=Yes;FMT=Delimited'";

                return @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Endava\EndevLocal\SoftwareIDE\Unidad04\Lab02\bin\Debug" +
                    "Extended Properties='text;HDR=Yes;FMT=Delimited'";
            }
        }

        public override DataTable GetTabla()
        {
            using (OleDbConnection Conn = new OleDbConnection(connectionString)) 
            {
                OleDbCommand cmdSelect = new OleDbCommand("select * from agenda.txt", Conn);
                Conn.Open();
                OleDbDataReader reader = cmdSelect.ExecuteReader();
                DataTable contactos = new DataTable();
                if (reader != null)
                { 
                    contactos.Load(reader);
                }
                Conn.Close();
                return contactos;                    
            }
        }


    }
}

using System.Data;
using System.Data.OleDb;

namespace Lab02
{
    internal class ManejadorArchivoTxt : ManejadorArchivo
    {
        protected string connectionString
        {
            get
            {
                return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\repos\Net\Unidad04\Lab02\bin\Debug\net8.0;" +
                       "Extended Properties='text;HDR=Yes;FMT=Delimited;'";
            }
        }

        public override DataTable GetTabla()
        {
            using (
                OleDbConnection Conn = new OleDbConnection(connectionString)) 
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

        public override void AplicaCambios()
        {
            using (OleDbConnection Conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into agenda.txt values (@id, @nombre,@apellido, " +
                    "@email, @telefono)", Conn);
                cmdInsert.Parameters.Add("@id", OleDbType.Integer);
                cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@apellido", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@email", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdUpdate = new OleDbCommand("update agenda.txt set nombre=@nombre, apellido=@apellido, " +
                    "email=@email, telefono=@telefono where id=@id", Conn);
                cmdUpdate.Parameters.Add("@id", OleDbType.Integer);
                cmdUpdate.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@apellido", OleDbType.VarChar);                    
                cmdUpdate.Parameters.Add("@email", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdDelete = new OleDbCommand("delete from agenda.txt where id=@id", Conn);
                cmdDelete.Parameters.Add("@id", OleDbType.Integer);

                DataTable filasNuevas = this.misContactos.GetChanges(DataRowState.Added);
                DataTable filasModificadas = this.misContactos.GetChanges(DataRowState.Modified);
                DataTable filasEliminadas = this.misContactos.GetChanges(DataRowState.Deleted);
                
                Conn.Open();

                if(filasNuevas != null)
                {
                    foreach (DataRow fila in filasNuevas.Rows)
                    {
                        cmdInsert.Parameters["@id"].Value = fila["Id"];
                        cmdInsert.Parameters["@nombre"].Value = fila["Nombre"];
                        cmdInsert.Parameters["@apellido"].Value = fila["Apellido"];
                        cmdInsert.Parameters["@email"].Value = fila["Email"];
                        cmdInsert.Parameters["@telefono"].Value = fila["Telefono"];
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                if (filasModificadas != null)
                {
                    foreach (DataRow fila in filasModificadas.Rows)
                    {
                        cmdUpdate.Parameters["@id"].Value = fila["Id"];
                        cmdUpdate.Parameters["@nombre"].Value = fila["Nombre"];
                        cmdUpdate.Parameters["@apellido"].Value = fila["Apellido"];
                        cmdUpdate.Parameters["@email"].Value = fila["Email"];
                        cmdUpdate.Parameters["@telefono"].Value = fila["Telefono"];
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                if(filasEliminadas != null)
                {
                    foreach (DataRow fila in filasEliminadas.Rows)
                    {
                        cmdDelete.Parameters["@id"].Value = fila["Id", DataRowVersion.Original];
                        cmdDelete.ExecuteNonQuery();
                    }
                }

                Conn.Close();
            }
        }


    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    internal class ContactosMySql : Contactos
    {
        protected string connectionString
        {
            get { return "server=serverisi;database=net;uid=net;pwd=net;CharSet=utf8"; }
        }

        public override DataTable GetTabla()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM contactos", connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                DataTable contactos = new DataTable();
                if (reader != null)
                {
                    contactos.Load(reader);
                }
                connection.Close();
                return contactos;
            }
        }

        public override void AplicaCambios()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand commandInsert = new MySqlCommand("INSERT INTO contactos VALUES (@id, @nombre, @apellido, @email, @telefono)", connection);
                commandInsert.Parameters.Add("@id", MySqlDbType.Int32, 11, "id");
                commandInsert.Parameters.Add("@nombre", MySqlDbType.VarChar, 50, "nombre");
                commandInsert.Parameters.Add("@apellido", MySqlDbType.VarChar, 50, "apellido");
                commandInsert.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
                commandInsert.Parameters.Add("@telefono", MySqlDbType.VarChar, 20, "telefono");

                MySqlCommand commandUpdate = new MySqlCommand("UPDATE contactos SET nombre=@nombre, apellido=@apellido, email=@email," +
                    " telefono=@telefono WHERE id=@id", connection);
                commandUpdate.Parameters.Add("@id", MySqlDbType.Int32, 11, "id");
                commandUpdate.Parameters.Add("@nombre", MySqlDbType.VarChar, 50, "nombre");
                commandUpdate.Parameters.Add("@apellido", MySqlDbType.VarChar, 50, "apellido");
                commandUpdate.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
                commandUpdate.Parameters.Add("@telefono", MySqlDbType.VarChar, 20, "telefono");

                MySqlCommand commandDelete = new MySqlCommand("DELETE FROM contactos WHERE id=@id", connection);
                commandDelete.Parameters.Add("@id", MySqlDbType.Int32, 11, "id");

                DataTable filasNuevas = this.misContactos.GetChanges(DataRowState.Added);
                DataTable filasModificadas = this.misContactos.GetChanges(DataRowState.Modified);
                DataTable filasEliminadas = this.misContactos.GetChanges(DataRowState.Deleted);

                connection.Open();

                if (filasNuevas != null)
                {
                    foreach (DataRow fila in filasNuevas.Rows)
                    {
                        commandInsert.Parameters["@id"].Value = fila["id"];
                        commandInsert.Parameters["@nombre"].Value = fila["nombre"];
                        commandInsert.Parameters["@apellido"].Value = fila["apellido"];
                        commandInsert.Parameters["@email"].Value = fila["email"];
                        commandInsert.Parameters["@telefono"].Value = fila["telefono"];
                        commandInsert.ExecuteNonQuery();
                    }
                }
                if (filasModificadas != null)
                {
                    foreach (DataRow fila in filasModificadas.Rows)
                    {
                        commandUpdate.Parameters["@id"].Value = fila["id"];
                        commandUpdate.Parameters["@nombre"].Value = fila["nombre"];
                        commandUpdate.Parameters["@apellido"].Value = fila["apellido"];
                        commandUpdate.Parameters["@email"].Value = fila["email"];
                        commandUpdate.Parameters["@telefono"].Value = fila["telefono"];
                    }
                }
                if (filasEliminadas != null)
                {
                    foreach (DataRow fila in filasEliminadas.Rows)
                    {
                        commandDelete.Parameters["@id"].Value = fila["id", DataRowVersion.Original];
                        commandDelete.ExecuteNonQuery();
                    }
                }

                connection.Close();
                this.misContactos.AcceptChanges();
            }
        }
    }
}

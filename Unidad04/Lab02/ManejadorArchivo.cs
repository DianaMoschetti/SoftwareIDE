using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Lab02
{
    internal class ManejadorArchivo
    {
        protected DataTable misContactos;
        public ManejadorArchivo() 
        {
            this.misContactos = this.GetTabla();
        }

        public virtual DataTable GetTabla()
        {
            return new DataTable();
        }

        public virtual void AplicaCambios()
        {

        }

        public void Listar()
        {
            foreach (DataRow fila in this.misContactos.Rows)
            {
                if (fila.RowState != DataRowState.Deleted)
                {
                    foreach (DataColumn col in this.misContactos.Columns)
                    {
                        Console.WriteLine("{0}: {1}", col.ColumnName, fila[col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public void NuevaFila()
        {
            DataRow fila = this.misContactos.NewRow();
            foreach (DataColumn column in this.misContactos.Columns)
            {
                Console.Write("Ingrese {0}:", column.ColumnName);
                fila[column] = Console.ReadLine(); 
            }
            this.misContactos.Rows.Add(fila);
        }

        public void EditarFila()
        {
            Console.WriteLine("Ingrese el nro de fila a editar");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = this.misContactos.Rows[nroFila - 1];
            for (int nroCol = 1; nroCol < this.misContactos.Columns.Count; nroCol++)
            {
                DataColumn col = this.misContactos.Columns[nroCol];
                Console.WriteLine("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();

            }
        }

        public void EliminarFila()
        {
            Console.WriteLine("Ingrese el nro de fila a eliminar");
            int fila = int.Parse(Console.ReadLine());
            this.misContactos.Rows[fila - 1].Delete();
        }

    }
}

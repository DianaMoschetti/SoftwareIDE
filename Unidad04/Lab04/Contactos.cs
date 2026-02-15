using System.Data;

namespace Lab04
{
    internal class Contactos
    {
        protected DataTable misContactos;

        public Contactos()
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
        /* 
         En el método listar los contactos recorremos la colección Rows de la DataTable.
         Para listar el nombre de la columna recorremos la colección de columnas del DataTable y 
         utilizamos la propiedad ColumnName y para acceder a cada una de las celdas de la DataTable 
         recorremos la colección de filas (DataRows) con el foreach y luego para cada fila accedemos a  
         los valores de las celdas como si fuese un array pero no sólo podemos acceder con el índice de 
         la columna sino también con el nombre de la columna o como en este caso con el objeto columna.
         */
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

        public void NuevoContacto()
        {
            DataRow fila = this.misContactos.NewRow();
            foreach (DataColumn col in this.misContactos.Columns)
            {
                Console.Write("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();
            }
            this.misContactos.Rows.Add(fila);
        }

        public void EditarContacto()
        {
            Console.WriteLine("Ingrese el número de fila a editar");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = this.misContactos.Rows[nroFila - 1];
            for (int nroCol = 1; nroCol < this.misContactos.Columns.Count; nroCol++)
            //el 0 se omite por ser la ID
            {
                DataColumn col = this.misContactos.Columns[nroCol];
                Console.Write("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();
            }

        }

        public void EliminarFila()
        {
            Console.WriteLine("Ingrese el número de fila a eliminar");
            int fila = int.Parse(Console.ReadLine());
            this.misContactos.Rows[fila - 1].Delete();
        }

    }
}

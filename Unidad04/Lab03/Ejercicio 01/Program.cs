using System.Data;

namespace Ejercicio01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dtAlumnos = new DataTable();
            DataRow rwAlumno = dtAlumnos.NewRow();

            DataColumn colNombre = new DataColumn();
            DataColumn colApellido = new DataColumn();

            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colApellido);

            rwAlumno[colNombre] = "Juan";
            rwAlumno[colApellido] = "Perez";

            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2[colNombre] = "Maria";
            rwAlumno2[colApellido] = "Garcia";
            dtAlumnos.Rows.Add(rwAlumno2);

            Console.WriteLine("Listado de Alumnos");
            foreach (DataRow rw in dtAlumnos.Rows)
            {                
                Console.WriteLine(rw[colApellido].ToString() + ", " + rw[colNombre].ToString());
                Console.WriteLine("-------------");
            }
            Console.ReadLine();
        }
    }
}
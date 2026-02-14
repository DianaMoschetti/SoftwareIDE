using System.Data;

namespace Ejercicio02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dtAlumnos = new DataTable();

            DataColumn colIdAlumno = new DataColumn("IdAlumno", typeof(int));
            colIdAlumno.ReadOnly = true;
            colIdAlumno.AutoIncrement = true;
            colIdAlumno.AutoIncrementSeed = 1;
            colIdAlumno.AutoIncrementStep = 1;

            DataColumn colNombre = new DataColumn("Nombre", typeof(string));
            DataColumn colApellido = new DataColumn("Apellido", typeof(string));

            dtAlumnos.Columns.Add(colIdAlumno);
            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colApellido);

            // seteo pk
            dtAlumnos.PrimaryKey = new DataColumn[] { colIdAlumno };

            DataRow rwAlumno = dtAlumnos.NewRow();
            rwAlumno[colNombre] = "Juan";
            rwAlumno[colApellido] = "Perez";

            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2[colNombre] = "Maria";
            rwAlumno2[colApellido] = "Garcia";
            dtAlumnos.Rows.Add(rwAlumno2);

            DataTable dtCursos = new DataTable("Cursos");
            DataColumn colIdCurso = new DataColumn("IdCurso", typeof(int));
            colIdCurso.ReadOnly = true;
            colIdCurso.AutoIncrement = true;
            colIdCurso.AutoIncrementSeed = 1;
            colIdCurso.AutoIncrementStep = 1;
            DataColumn colCurso = new DataColumn("Curso", typeof(string));
            dtCursos.Columns.Add(colIdCurso);
            dtCursos.Columns.Add(colCurso);

            DataRow rwCurso = dtCursos.NewRow();
            rwCurso[colCurso] = "Informatica";
            dtCursos.Rows.Add(rwCurso);

            // Agrego las tablas a un dataset
            DataSet dsUniversidad = new DataSet("Universidad");
            dsUniversidad.Tables.Add(dtAlumnos);
            dsUniversidad.Tables.Add(dtCursos);

            // Creo la tabla de relación entre las tablas Cursos y Alumnos
            DataTable dtAlumnosCursos = new DataTable("AlumnosCursos");
            DataColumn colACIdAlumno = new DataColumn("IdAlumno", typeof(int));
            DataColumn colACIdCurso = new DataColumn("IdCurso", typeof(int));
            dtAlumnosCursos.Columns.Add(colACIdAlumno);
            dtAlumnosCursos.Columns.Add(colACIdCurso);
            dsUniversidad.Tables.Add(dtAlumnosCursos);

            // Creo las relaciones entre las tablas
            DataRelation dataRelationAlumnoCurso = new DataRelation("Alumno_Cursos", colIdAlumno, colACIdAlumno);
            DataRelation dataRelationCursoAlumno = new DataRelation("Curso_Alumnos", colIdCurso, colACIdCurso);
            dsUniversidad.Relations.Add(dataRelationAlumnoCurso);
            dsUniversidad.Relations.Add(dataRelationCursoAlumno);

            // Creo los registros de la tabla de relación
            DataRow rwAlumnosCurso = dtAlumnosCursos.NewRow();
            rwAlumnosCurso[colACIdAlumno] = 1; // IdAlumno de Juan
            rwAlumnosCurso[colACIdCurso] = 1; // IdCurso de Informatica
            dtAlumnosCursos.Rows.Add(rwAlumnosCurso);

            rwAlumnosCurso = dtAlumnosCursos.NewRow();
            rwAlumnosCurso[colACIdAlumno] = 2;
            rwAlumnosCurso[colACIdCurso] = 1;
            dtAlumnosCursos.Rows.Add(rwAlumnosCurso);


            Console.WriteLine("Ingrese el nombre del curso: ");
            string nombreCurso = Console.ReadLine();
            Console.WriteLine($"Alumnos inscriptos en el curso {nombreCurso}:");
            DataRow[] alumnosEnCurso = dtCursos.Select("Curso = '" + nombreCurso + "'");
            foreach (DataRow alumnoCurso in alumnosEnCurso)
            {
                DataRow[] alumnos = alumnoCurso.GetChildRows(dataRelationCursoAlumno);
                foreach (DataRow alumno in alumnos)
                {
                    Console.WriteLine(alumno.GetParentRow(dataRelationAlumnoCurso)[colApellido].ToString() + ", "+
                        alumno.GetParentRow(dataRelationAlumnoCurso)[colNombre].ToString());
                }
            }
            Console.ReadLine();
        }

    }
}
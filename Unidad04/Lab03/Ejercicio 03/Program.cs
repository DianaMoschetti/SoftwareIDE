using Ejercicio_03;
using System.Data;

namespace Ejercicio03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dsUniversidad universidad = new dsUniversidad();

            dsUniversidad.dtAlumnosDataTable dtAlumnos = new dsUniversidad.dtAlumnosDataTable();
            dsUniversidad.dtCursosDataTable dtCursos = new dsUniversidad.dtCursosDataTable();
            dsUniversidad.dtAlumnosRow rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Nombre = "Juan";
            rowAlumno.Apellido = "Pérez";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            dsUniversidad.dtCursosRow rowCurso = dtCursos.NewdtCursosRow();
            rowCurso.NombreCurso = "Informatica";
            dtCursos.AdddtCursosRow(rowCurso);

            dsUniversidad.dtAlumnosCursosDataTable dtAlumnosCursos = new dsUniversidad.dtAlumnosCursosDataTable();
            dsUniversidad.dtAlumnosCursosRow rowAlumnoCurso = dtAlumnosCursos.NewdtAlumnosCursosRow();
            dtAlumnosCursos.AdddtAlumnosCursosRow(rowAlumno, rowCurso);

            rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Nombre = "María";
            rowAlumno.Apellido = "Perez";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            dtAlumnosCursos.AdddtAlumnosCursosRow(rowAlumno, rowCurso);            
        }

    }
}
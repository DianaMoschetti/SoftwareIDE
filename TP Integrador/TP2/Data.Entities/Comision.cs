using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int AnioEspecialidad { get; set; }
        public int IdPlan { get; set; }

        private string _descripcion;
        private int _anioEspecialidad;
        private int _idPlan;
    }
}

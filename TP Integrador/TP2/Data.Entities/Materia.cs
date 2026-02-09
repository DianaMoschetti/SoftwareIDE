using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int HsSemanales { get; set; }
        public int HsTotales { get; set; }
        public int IdPlan { get; set; }

        private string _descripcion;
        private int _hsSemanales;
        private int _hsTotales;
        private int _idPlan;
    }
}

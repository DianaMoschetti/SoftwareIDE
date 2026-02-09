using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario
    {
        public int IdModulo { get; set; }
        public int IdUsuario { get; set; }
        public bool PermiteAlta { get; set; }
        public bool PermiteBaja { get; set; }
        public bool PermiteConsulta { get; set; }
        public bool PermiteModificacion { get; set; }
    }
}

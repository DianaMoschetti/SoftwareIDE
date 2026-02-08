using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    internal class Plan
    {
        public int Id { get; set; }
        public int IdEspecialidad { get; set; }
        public string DescPlan { get; set; }

        private int _idEspecialidad;
        private string _descPlan;
    }
}

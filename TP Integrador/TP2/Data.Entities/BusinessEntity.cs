using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {       

        public enum States
        {
            Deleted = 0,
            New = 1,
            Modified = 2,
            Unmodified = 3
        }
        public int Id { get; set; }
        public States State { get; set; }

        private int _id;
        private States _state;
        


    }
}

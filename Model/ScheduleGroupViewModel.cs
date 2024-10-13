using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ScheduleGroupViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private string nameId;

        public string NameId
        {
            get
            {
                return nameId;
            }
            set
            {
                nameId = value;
            }
        }
    }
}

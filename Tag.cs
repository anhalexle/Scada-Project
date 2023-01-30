using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_OPC_UA
{
    public class Tag
    {
        public string Name;
        public string Address;
        public object Value;
        public DateTime TimeStamp;

        public Motor Parents;

        public Tag(string name, string addr)
        {
            Name = name;
            Address = addr;
        }
    }
}

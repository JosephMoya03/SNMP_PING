using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_PING_Protocols.Domain
{
    public class Devices
    {

        public string IP { get; set; }
        public int port { get; set; }
        public List<string> OIDs { get; set; }


      

    }//End class
}//End namespace

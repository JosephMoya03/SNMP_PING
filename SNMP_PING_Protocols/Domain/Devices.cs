using Lextm.SharpSnmpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_PING_Protocols.Domain
{
    public class Devices
    {
        public Devices(int id, string IP, int port, List<string> OIDs)
        {
            this.id = id;
            this.IP = IP;
            this.port = port;
            this.OIDs = OIDs;
        }

        public int id { get; set; }
        public string IP { get; set; }
        public int port { get; set; }
        public List<string> OIDs { get; set; }




    }//End class
}//End namespace

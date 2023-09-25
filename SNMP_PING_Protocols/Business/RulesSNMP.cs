using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_PING_Protocols.Business
{
    public class RulesSNMP
    {
        
        public RulesSNMP() { }

        public string warnigBandWith(double bandWith)
        {
            string warning = "";

            if (bandWith < 9)
            {
                warning = "Se lanza la regla de alerta de ancho de banda";
            }

            return warning;
        }




    }//End class
}//End namespace

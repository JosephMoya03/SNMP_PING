using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_PING_Protocols.Business
{
    public class RulesPing
    {

        public RulesPing(){}

        public string errorResponseConection(string responseOfDevice)
        {
            string error = "";

            if (responseOfDevice != "Success")
            {
                error =  "Se dispara la regla de error de coneccion";
            }

            return error;
        }


        public string lostPacket(double lostPackages)
        {
            string error = "";

            if(lostPackages >= 1)
            {
                error = "Se lanza la regla de que se perdieron paquetes";
            }

            return error;
        }

        public string lostPacketAverage(double lostPackages)
        {
            string error = "";

            if (lostPackages >= 50)
            {
                error = "Se lanza la regla de que se perdieron la mitad o mas de los paquetes";
            }

            return error;
        }


        public string latencyResonse(long latency)
        {
            string error = "";

            if (latency > 1)
            {
                error = "Se lanza la regla de latencia superior a N Ms";    
            }

            return error;
        }


    }//End class
}//End namespace

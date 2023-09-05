using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SNMP_PING_Protocols
{
    internal class SNMP_PING_Protocols
    {
        static void Main(string[] args)
        {
            
            PING pingClass = new PING();
            SNMP snmpClass = new SNMP();

            string input;

            do
            {
                Console.WriteLine("Eliga una opcion: " +
                    "\n1) Protocolo PING ICMP " +
                    "\n2) Protocolo Simple network management protocol SNMP " +
                    "\n3) Ambos protocolos Ping & SNMP" +
                    "0) Salir");
                input = Console.ReadLine(); // Asigna un valor a la variable

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            pingClass.testPing("192.168.0.1", 161, 4);
                            break;

                        case 2:
                            snmpClass.testSNMP("192.168.0.10", 161);
                            break;

                        case 3:
                            pingClass.testPing("192.168.0.1", 161, 4);
                            snmpClass.testSNMP("192.168.0.10", 161);
                            break;
                    }
                }

            } while (input != "0");


        }//End Main
    }//End class
}//End namespace

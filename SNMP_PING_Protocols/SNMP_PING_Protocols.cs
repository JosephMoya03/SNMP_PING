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
            string ipAddres = "192.168.0.12"; // 192.168.0.15

            do
            {
                Console.WriteLine("\nEliga una opcion: " +
                    "\n1) Protocolo PING ICMP " +
                    "\n2) Protocolo Simple network management protocol SNMP " +
                    "\n3) Ambos protocolos Ping & SNMP" +
                    "\n0) Salir");
                input = Console.ReadLine(); // Asigna un valor a la variable

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            pingClass.testPing(ipAddres, 4);
                            break;

                        case 2:
                            snmpClass.testSNMP(ipAddres, 161);
                            break;

                        case 3:
                            pingClass.testPing(ipAddres, 4);
                            snmpClass.testSNMP(ipAddres, 161);
                            break;
                    }
                }

            } while (input != "0");


        }//End Main
    }//End class
}//End namespace

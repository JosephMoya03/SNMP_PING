using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using SNMP_PING_Protocols.PING_Protocol;
using SNMP_PING_Protocols.Resources;
using SNMP_PING_Protocols.SNMP_Protocol;
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


            //Instances
            PING pingClass = new PING();
            SNMP snmpClass = new SNMP();
            ManagementFiles managementFiles = new ManagementFiles();


            //managementFiles.writerJsonFile(); //Sobre escribir las IPS

            int input = 3;
            int loop = 2;
            string ipAddres = "";
            int IdOfDevice = 0;
            int opc = 0;
            Console.WriteLine("Bienvenido al sistema Noc-Poc, para el monitoreo de dispositivos mediante protocolos SNMP y PING.");


            do
            {
                if (loop == 2)
                {
                    loop = 1;
                    Console.WriteLine(
                       "\n1)Verificar un dispositivo registrado" +
                        "\n2)Ingresar un nuevo dispositivo" +
                        "\n3)Salir");
                    Console.Write("\nSeleecione una opción: ");
                    input = int.Parse(Console.ReadLine());
                    opc = input;
                    Console.Clear();

                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("\nLista de dispositivos registrados en el sistema:\n");
                            Console.WriteLine(managementFiles.getStringAllIPs());
                            Console.Write("Seleccione la IP del dispositivo que desea monitorear: ");
                            IdOfDevice = int.Parse(Console.ReadLine()) - 1;
                            Console.Clear();
                            break;
                        case 2:
                            Console.Write("\nIngrese la Ip a utilizar: ");
                            ipAddres = Console.ReadLine();
                            managementFiles.writerJsonFile(ipAddres);
                            Console.Clear();
                            break;

                        case 3:
                            break;

                    }//switch
                }//If loop1


                if (loop == 1)
                {
                    Console.WriteLine("\nCual protocolo desea utlizar para llevar a cabo el monitoreo del dispositivo seleccionado:\n" +
                        "\n1)Protocolo ICMP PING" +
                        "\n2)Protocolo Simple network management protocol SNMP " +
                        "\n3)Salir");
                    Console.Write("\nSeleccione una opción: ");
                    input = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (input)
                    {
                        case 1:
                            Console.Write("\nPorfavor indique cuantos paquetes desea enviar para hacer el monitoreo con el protocolo PING: ");
                            int quantityPackage = int.Parse(Console.ReadLine());
                            pingClass.testPing(managementFiles.selecttIpDevice(IdOfDevice, opc), quantityPackage);
                            break;

                        case 2:
                            snmpClass.testSNMP(managementFiles.selecttIpDevice(IdOfDevice, opc), managementFiles.selecttPortDevice(IdOfDevice, opc), managementFiles.getAllOids(IdOfDevice, opc));
                            break;

                        case 3:
                            break;

                    }//Switch 
                }//if loop2 

                Console.WriteLine("\nEl testeo concluyó satisfactoriamente\n" +
                    "\n1)Monitorear el dispositivo seleccionado anteriormente" +
                    "\n2)Monitorear un nuevo dispositivo" +
                    "\n3)Salir");
                Console.Write("\nSelecccione una opción: ");
                loop = int.Parse(Console.ReadLine());
                Console.Clear();

                if (loop == 3)
                    input = 3;

            } while (input != 3);



        }//End Main
    }//End class
}//End namespace

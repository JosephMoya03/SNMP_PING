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

//test
//test
namespace SNMP_PING_Protocols
{
    internal class SNMP_PING_Protocols
    {
        static void Main(string[] args)
        {
            //Instances
            PING pingClass = new PING();
            SNMP snmpClass = new SNMP();
            ReaderFiles readerFiles = new ReaderFiles();

            int input= 3;
            int loop = 2;
            string ipAddres = "";
            int IdOfDevice = 0;

            Console.WriteLine("Bienvenido al sistema Noc-Poc.");


            do
            {
                if(loop == 2) {
                    loop = 1;
                    Console.WriteLine(
                       "\n1) Verificar un dispositivo registrado" +
                        "\n2) Ingresar un nuevo dispositivo" +
                        "\n3)Salir");
                    Console.Write("\nElija una opción: ");
                    input = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("\nLista de dispositivos:");
                            Console.WriteLine(readerFiles.deviceDisplay());
                            Console.Write("Elija el dispositivo a monitorear: ");
                            IdOfDevice = int.Parse(Console.ReadLine()) - 1;
                            Console.Clear();
                            break;
                        case 2:
                            Console.Write("\nIngrese la Ip a utilizar: ");
                            ipAddres = Console.ReadLine();
                            Console.Clear();
                            break;

                        case 3:
                            break;

                    }//switch
                }//If loop1


                if(loop == 1) { 
                    Console.WriteLine("\nCon cual protocolo desea hacer el monitoreo" +
                        "\n1) Protocolo ICMP PING" +
                        "\n2) Protocolo Simple network management protocol SNMP " +
                        "\n3) Salir");
                    Console.Write("\nElija una opción: ");
                    input = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (input)
                    {
                        case 1:
                            Console.Write("\nCuantos paquetes desea enviar: ");
                            int quantityPackage = int.Parse(Console.ReadLine());
                            pingClass.testPing(readerFiles.selecttDevice(IdOfDevice), quantityPackage);
                            break;

                        case 2:
                            Console.Write("\nEn cual puerto se aloja el dispositivo: ");
                            int port = int.Parse(Console.ReadLine());
                            snmpClass.testSNMP(readerFiles.selecttDevice(IdOfDevice), port);
                            break;

                        case 3:
                            break;

                    }//Switch 
                }//if loop2 

                Console.WriteLine("\nTesteo completado\n" +
                    "\n1)Monitorear nuevamente el dispositivo" +
                    "\n2)Monitorear otro dispositivo" +
                    "\n3)Salir");
                Console.Write("\nElija una opción: ");
                loop = int.Parse(Console.ReadLine());
                Console.Clear();

                if (loop == 3)
                    input = 3;

            } while (input != 3);


        }//End Main
    }//End class
}//End namespace

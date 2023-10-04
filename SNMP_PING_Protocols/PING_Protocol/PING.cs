using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SNMP_PING_Protocols.Business;

namespace SNMP_PING_Protocols.PING_Protocol
{
    public class PING
    {

        //Instances
        RulesPing rulesPing; 


        //Varibles
        int successfulPings = 0;
        double lossPing = 0;
        double packetLoss = 0;
        bool databaseInformortaion = false;



        //Builders
        public PING() 
        { 
            rulesPing = new RulesPing();
        }


        //Methods
        public void testPing(string IP, int totalPings)
        {
              
            try
            {
                Ping ping = new Ping();
                

                
                for (int i = 0; i < totalPings; i++)
                {
                    PingReply reply = ping.Send(IP);

                    if (reply.Status == IPStatus.Success)
                    {
                        if (!databaseInformortaion)
                        {
                            //Console.WriteLine("\nIP: " + IP + ", Estatus: " + reply.Status + ", Latencia actual: " + rulesPing.latencyResonse(reply.RoundtripTime) + reply.RoundtripTime + "Ms");
                            Console.WriteLine("\nDerección IP: " + IP + "\nEstado del dispositivo: " + reply.Status + "\nLatencia actual: " + rulesPing.latencyResonse(reply.RoundtripTime) + reply.RoundtripTime + "Ms");
                        }
                        


                        else
                        {
                            Console.WriteLine(reply.Status + " Estatus " +
                                 "\n" + reply.RoundtripTime + " MS" +
                                 "\n" + reply.Address + " Address \n");
                        }
                        successfulPings++;
                    }
                    else Console.WriteLine(rulesPing.errorResponseConection(Convert.ToString(reply.Status)));
                }//for

                //Conversar si el cliente desea lanzar la alerta y realizar el proceso o solo una de las 2 cosas
                Console.WriteLine(rulesPing.lostPacket(lossPing));
                Console.WriteLine(rulesPing.lostPacketAverage(packetLoss));

                lossPing = totalPings - successfulPings;
                packetLoss = lossPing / totalPings * 100;
                Console.WriteLine($"Paquetes: Enviados= {totalPings}, Recibidos= {successfulPings}, Perdidos= {lossPing}");
                Console.WriteLine($"Porcentaje de paquetes perdidos= {packetLoss}%");

                

                successfulPings = 0;

                if (databaseInformortaion)
                    displayInformationTracer(IP);
            }//try

            catch (PingException ex)
            {
                Console.WriteLine("Error de ping: " + ex.Message);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Error de socket: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Otro error: " + ex.Message);
            }
        }//TestPing


        public void displayInformationTracer(string IP)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "tracert";

            startInfo.Arguments = IP;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            process.StartInfo = startInfo;

            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine(e.Data);
                }
            });
            process.Start();
            process.BeginOutputReadLine();

            process.WaitForExit();
        }


    }//End class
}//End namespace

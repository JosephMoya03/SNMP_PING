using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace SNMP_PING_Protocols.PING_Protocol
{
    public class PING
    {

        int successfulPings = 0;
        double lossPing = 0;
        double packetLoss = 0;
        bool databaseInformortaion = false;


        //Builders
        public PING() { }


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
                            Console.WriteLine(reply.Status + " Estatus ");

                        else
                        {
                            Console.WriteLine(reply.Status + " Estatus " +
                                 "\n" + reply.RoundtripTime + " MS" +
                                 "\n" + reply.Address + " Address \n");
                        }
                        successfulPings++;
                    }
                    else Console.WriteLine("Error " + reply.Status);
                }//for

                lossPing = totalPings - successfulPings;
                packetLoss = lossPing / totalPings * 100;
                Console.WriteLine($"Paquetes: Enviados = {totalPings}, Recibidos = {successfulPings}, Perdidos = {lossPing}");
                Console.WriteLine($"Perdidos = {packetLoss}%");

                successfulPings=0;

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

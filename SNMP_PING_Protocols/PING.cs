using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace SNMP_PING_Protocols
{
    public class PING
    {
        string IP =  "192.168.0.5";
        int totalPings = 4;
        int successfulPings = 0;
        double lossPing = 0;
        double packetLoss = 0;

        //Builders
        public PING(){ }

        public PING(string iP, int totalPings)
        {
            this.IP = iP;
            this.totalPings = totalPings;
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
                        this.successfulPings++;
                        Console.WriteLine(reply.Status + " Estatus " +
                            "\n" + reply.RoundtripTime + " MS" +
                            "\n" + reply.Address + " Address \n");

                    }
                    else Console.WriteLine("Error " + reply.Status);
                }
                this.lossPing = (double)(totalPings - successfulPings);
                this.packetLoss = (lossPing / totalPings) * 100;
                Console.WriteLine($"Paquetes: Enviados = {totalPings}, Recibidos = {successfulPings}, Perdidos = {lossPing}");
                Console.WriteLine($"Perdidos = {packetLoss}%");

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                //startInfo.FileName = (Environment.OSVersion.Platform == PlatformID.Unix) ? "traceroute" : "tracert";
                startInfo.FileName = "tracert";

                startInfo.Arguments = IP;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;

                process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        Console.WriteLine(e.Data);
                    }
                });
                process.Start();
                process.BeginOutputReadLine();

                process.WaitForExit();
                Console.WriteLine("Tracert completado.");
            }
             
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


    }//End class
}//End namespace

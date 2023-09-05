using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_PING_Protocols
{
    public class PING
    {
        string IP =  "127.0.0.1";
        int port = 161;
        int totalPings = 4;


        //Builders
        public PING(){ }

        public PING(string iP, int port, int totalPings)
        {
            this.IP = iP;
            this.port = port;
            this.totalPings = totalPings;
        }


        //Methods
        public void testPing(string ip, int port, int totalPings)
        {
            var target = new IPEndPoint(IPAddress.Parse(IP), port);

            try
            {
                Ping ping = new Ping();


                for (int i = 0; i < totalPings; i++)
                {
                    PingReply reply = ping.Send(IP);

                    if (reply.Status == IPStatus.Success)
                        Console.WriteLine(reply.Status + " Estatus " +
                            "\n" + reply.RoundtripTime + " MS" +
                            "\n" + reply.Address + " Address \n");

                    else Console.WriteLine("Error " + reply.Status);
                }
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

using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_PING_Protocols.SNMP_Protocol
{
    public class SNMP
    {
  
        VersionCode version = VersionCode.V2;
        OctetString community = new OctetString("public");

        //Buildiers
        public SNMP() { }


        public void testSNMP(string IP, int port)
        {

            var endpoint = new IPEndPoint(IPAddress.Parse(IP), port);

            //Lista de OIDs
            List<ObjectIdentifier> oids = new List<ObjectIdentifier>
            {
                new ObjectIdentifier("1.3.6.1.2.1.1.5.0")  //Nombre o direccion  
                ,new ObjectIdentifier("1.3.6.1.2.1.1.6.0")  //Localisacion 
                ,new ObjectIdentifier("1.3.6.1.2.1.1.2.0") //Nombre del fabricante 
                ,new ObjectIdentifier("1.3.6.1.2.1.1.3.0") //Numero de serie 
                ,new ObjectIdentifier("1.3.6.1.2.1.1.4.0") //Version del software
                //,new ObjectIdentifier("1.3.6.1.2.1.1.1.0") //
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.2.2") //Informacion de las tablas
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.10.2") //Velocidad de entrada
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.14.2") //Errores de entrada //recepcion de datos perdida de paquetes, paquetes dañados
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.16.2") //Velocidad de salida 
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.20.1") //Errores de salida //recepcion de datos perdida de paquetes, paquetes dañados
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.5.2") //Speed 
            };

            // Crea una lista de variables SNMP utilizando los OIDs
            var variables = new List<Variable>();
            foreach (var oid in oids)
            {
                variables.Add(new Variable(oid));
            }

            try
            {
                var result = Messenger.Get(version, endpoint, community, variables, 9000);

                if (result != null && result.Count > 0)
                {
                    foreach (var v in result)
                    {
                        Console.WriteLine($"{v.Id.ToString()} = {v.Data.ToString()}");
                    }
                    bandwidthTest(result);
                }
                else
                {
                    Console.WriteLine("No se obtuvo respuesta del dispositivo SNMP.");
                }
                
            }//try

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }//EndTestSNMP


        public void bandwidthTest(IList<Variable> result)
        {
            var ifInOctets = (Counter32)result[6].Data;
            var ifOutOctets = (Counter32)result[8].Data;
            var ifSpeed = (Gauge32)result[10].Data;
            double bandwidthUsage = ((ifInOctets.ToUInt32() + ifOutOctets.ToUInt32()) * 8.0) / (ifSpeed.ToUInt32() * 1000);
            Console.WriteLine($"Uso del ancho de banda: {bandwidthUsage} kbps");
        }//.EndBandwidthTest


    }//End class
}//End namespace

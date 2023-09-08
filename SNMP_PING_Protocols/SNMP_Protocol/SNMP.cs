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

            var endpoint = new IPEndPoint(IPAddress.Parse(IP), port); //192.168.0.10 

            //Lista de OIDs
            List<ObjectIdentifier> oids = new List<ObjectIdentifier>
            {
                new ObjectIdentifier("1.3.6.1.2.1.1.5.0")  //Nombre o direccion  
                ,new ObjectIdentifier("1.3.6.1.2.1.1.6.0")  //Localisacion 
                ,new ObjectIdentifier("1.3.6.1.2.1.1.2.0") //Nombre del fabricante 
                ,new ObjectIdentifier("1.3.6.1.2.1.1.3.0") //Numero de serie 
                ,new ObjectIdentifier("1.3.6.1.2.1.1.4.0") //Version del software
                //,new ObjectIdentifier("1.3.6.1.2.1.1.1.0") //
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.2.9") //Informacion de las tablas
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.10.9") //Velocidad de entrada
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.14.9") //Errores de entrada //recepcion de datos perdida de paquetes, paquetes dañados
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.16.9") //Velocidad de salida 
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.20.1") //Errores de salida //recepcion de datos perdida de paquetes, paquetes dañados
                ,new ObjectIdentifier("1.3.6.1.2.1.2.2.1.5.9") //Speed 
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



    }//End class
}//End namespace

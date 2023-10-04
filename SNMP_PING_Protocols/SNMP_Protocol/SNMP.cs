using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using SNMP_PING_Protocols.Business;
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

        //Instance
        RulesSNMP rulesSNMP;


        VersionCode version = VersionCode.V2;
        OctetString community = new OctetString("public");

        //Buildiers
        public SNMP() 
        {
            rulesSNMP = new RulesSNMP();   
        }


        public void testSNMP(string  IP, int port, List<string> oidsStr)
        {
            Console.WriteLine("Resultados del monitoreo con el protocolo SNMP\n" +
                "\nIP del dispositivo monitoreado: " + IP + "\n");
            var endpoint = new IPEndPoint(IPAddress.Parse(IP), port);

            //Lista de OIDs
            List<ObjectIdentifier> oids = new List<ObjectIdentifier>();

            foreach (var oidStr in oidsStr)
            {
                oids.Add(new ObjectIdentifier(oidStr));
            }

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
                    int count = 0;
                    foreach (var v in result)
                    {
                        string variable = variablesName()[count];
                        Console.WriteLine($"{variable}, OID: {v.Id.ToString()}\n{v.Data.ToString()}\n");
                        count++;
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

            Console.WriteLine(rulesSNMP.warnigBandWith(bandwidthUsage));

        }//.EndBandwidthTest


        public List<string> variablesName()
        {
            return new List<string>
                {
                   "Nombre o dirección del dispositivo"
                ,"Localisación del dispositivo"
                ,"Fabricante del dispositivo"
                ,"Tiempo de actividad del dispositivo"
                ,"Información de contacto del dispositivo"
                ,"Información de las tablas del dispositivo"
                ,"Velocidad de entrada del dispositivo"
                ,"Errores de entrada del dispositivo"
                ,"Velocidad de salida del dispositivo"
                ,"Errores de salida del dispositivo"
                ,"Velocidad de interfaz"
                };
        }

    }//End class
}//End namespace

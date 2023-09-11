 
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Lextm.SharpSnmpLib;
using SNMP_PING_Protocols.Domain;

namespace SNMP_PING_Protocols.Resources
{
    public class ManagementFiles
    {
        

        public List<Devices> createListDevices()
        {
            List<Devices> devices = new List<Devices>();

            devices.Add(new Devices
            {
                IP = "192.168.0.5",
                port = 161,
                OIDs = new List<string>
                {
                     "1.3.6.1.2.1.1.5.0"  //Nombre o direccion  
                    ,"1.3.6.1.2.1.1.6.0"  //Localisacion 
                    ,"1.3.6.1.2.1.1.2.0" //Nombre del fabricante 
                    ,"1.3.6.1.2.1.1.3.0" //Numero de serie 
                    ,"1.3.6.1.2.1.1.4.0" //Version del software
                    //("1.3.6.1.2.1.1.1.0" //
                    ,"1.3.6.1.2.1.2.2.1.2.2" //Informacion de las tablas
                    ,"1.3.6.1.2.1.2.2.1.10.2" //Velocidad de entrada
                    ,"1.3.6.1.2.1.2.2.1.14.2" //Errores de entrada //recepcion de datos perdida de paquetes, paquetes dañados
                    ,"1.3.6.1.2.1.2.2.1.16.2" //Velocidad de salida 
                    ,"1.3.6.1.2.1.2.2.1.20.1" //Errores de salida //recepcion de datos perdida de paquetes, paquetes dañados
                    ,"1.3.6.1.2.1.2.2.1.5.2" //Speed 
                }

            });

            devices.Add(new Devices
            {
                IP = "192.168.0.1",
                port = 161,
                OIDs = new List<string>
                {
                     "1.3.6.1.2.1.1.5.0"  //Nombre o direccion  
                    ,"1.3.6.1.2.1.1.6.0"  //Localisacion 
                    ,"1.3.6.1.2.1.1.2.0" //Nombre del fabricante 
                    ,"1.3.6.1.2.1.1.3.0" //Numero de serie 
                    ,"1.3.6.1.2.1.1.4.0" //Version del software
                    //("1.3.6.1.2.1.1.1.0" //
                    ,"1.3.6.1.2.1.2.2.1.2.2" //Informacion de las tablas
                    ,"1.3.6.1.2.1.2.2.1.10.2" //Velocidad de entrada
                    ,"1.3.6.1.2.1.2.2.1.14.2" //Errores de entrada //recepcion de datos perdida de paquetes, paquetes dañados
                    ,"1.3.6.1.2.1.2.2.1.16.2" //Velocidad de salida 
                    ,"1.3.6.1.2.1.2.2.1.20.1" //Errores de salida //recepcion de datos perdida de paquetes, paquetes dañados
                    ,"1.3.6.1.2.1.2.2.1.5.2" //Speed 
                }

            });

            return devices;
        }

        public void writerJsonFile() {


            var options = new JsonSerializerOptions
            {
               WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(createListDevices(), options);
            string filePath = @"C:\Users\josep\Desktop\Universidad\Practica\SNMP_PING\SNMP_PING_Protocols\Resources\nombre_personalizado.json";

            File.WriteAllText(filePath, jsonString);
        }


        public List<Devices> readerJsonFile()
        {
            string filePath = @"C:\Users\josep\Desktop\Universidad\Practica\SNMP_PING\SNMP_PING_Protocols\Resources\nombre_personalizado.json";
            string jsonString = File.ReadAllText(filePath);

            List<Devices> devicesList = JsonSerializer.Deserialize<List<Devices>>(jsonString);


            foreach (Devices objeto in devicesList)
            {
                Console.WriteLine($"IP: {objeto.IP}");
            }

            return devicesList;
        }


    }//End class
}//End namespace

 
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Lextm.SharpSnmpLib;
using SNMP_PING_Protocols.Domain;

namespace SNMP_PING_Protocols.Resources
{
    public class ManagementFiles
    {
        private List<Devices> devicesList;

        public ManagementFiles() {
            string filePath = "../../../Resources/nombre_personalizado.json";
            writerJsonFile(filePath);
            string jsonString = File.ReadAllText(filePath);
            devicesList = JsonSerializer.Deserialize<List<Devices>>(jsonString);
          
        }

        public List<Devices> createListDevices()
        {
            List<Devices> devices = new List<Devices>();

            devices.Add(new Devices
            {
                id= 0,
                IP = "192.168.0.11",
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
                id = 0,
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

            devices.Add(new Devices
            {
                id = 0,
                IP = "ffd1:25fb:2893:47ab%10",
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

        public void writerJsonFile(string filePath)
        {

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(createListDevices(), options);
            //string filePath = @"../../../Resources/nombre_personalizado.json";

            File.WriteAllText(filePath, jsonString);
        }

        public string getStringAllIPs()
        {
            string IPList = "";
            
            for (int i = 0; i < devicesList.Count; i++)
            {
                Devices objeto = devicesList[i];
                IPList += ($"{i + 1}) IP: {objeto.IP}\n");
            }

            return IPList;
        }

        public List<string> getAllIPs()
        {
            List<string> listIps = new List<string>();
            
            for (int i = 0; i < devicesList.Count; i++)
            {
                Devices objeto = devicesList[i];
                listIps.Add(objeto.IP);
            }

            return listIps;
        }

        public List<string> getAllOids(int IdOfDevice)
        {
            List<string> listOids = new List<string>();

            foreach (var device in devicesList)
            {
                
                    foreach (var oid in device.OIDs)
                    {
                        if (IdOfDevice == device.id)
                        {
                            listOids.Add(oid);
                        }
                    }
            }
            return listOids;

        }
        public Devices FindDeviceById(int id)
        {
            return devicesList.Find(device => device.id == id);
        }

        public string selecttIpDevice(int device)
        {
            List<string> listOfDevice = getAllIPs();

            return listOfDevice[device];
        }


        public List<int> getAllPort()
        {
            List<int> listIps = new List<int>();

            for (int i = 0; i < devicesList.Count; i++)
            {
                Devices objeto = devicesList[i];
                listIps.Add(objeto.port);
            }

            return listIps;
        }

        public int selecttPortDevice(int device )
        {
            List<int> listOfDevice = getAllPort();

            return listOfDevice[device];
        }

    }//End class
}//End namespace

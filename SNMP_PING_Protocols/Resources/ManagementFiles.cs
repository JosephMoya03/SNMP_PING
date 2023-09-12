 
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
        private string filePath = "../../../Resources/nombre_personalizado.json";
        public ManagementFiles() {

            // Paso 1: Leer el contenido existente del archivo JSON en una lista
            devicesList = LoadDevicesFromJsonFile(filePath);
            
        }
        public static List<Devices> LoadDevicesFromJsonFile(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Devices>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde el archivo JSON: {ex.Message}");
                return new List<Devices>();
            }
        }
        public static void SaveDevicesToJsonFile(string filePath, List<Devices> devices)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(devices, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en el archivo JSON: {ex.Message}");
            }
        }

        public void writerJsonFile(string IP)
        {
            // Paso 2: Agregar un nuevo dispositivo (por ejemplo)
            
            devicesList.Add(new Devices
                (   
                devicesList.Count+1,
                IP,
                161,
                new List<string>
                {
                    "1.3.6.1.2.1.1.5.0"  //Nombre o direccion  
                ,"1.3.6.1.2.1.1.6.0"  //Localisacion 
                ,"1.3.6.1.2.1.1.2.0" //Nombre del fabricante 
                ,"1.3.6.1.2.1.1.3.0" //Numero de serie 
                ,"1.3.6.1.2.1.1.4.0" //Version del software
                //,new ObjectIdentifier("1.3.6.1.2.1.1.1.0") //
                ,"1.3.6.1.2.1.2.2.1.2.2" //Informacion de las tablas
                ,"1.3.6.1.2.1.2.2.1.10.2" //Velocidad de entrada
                ,"1.3.6.1.2.1.2.2.1.14.2" //Errores de entrada //recepcion de datos perdida de paquetes, paquetes dañados
                ,"1.3.6.1.2.1.2.2.1.16.2" //Velocidad de salida 
                ,"1.3.6.1.2.1.2.2.1.20.1" //Errores de salida //recepcion de datos perdida de paquetes, paquetes dañados
                ,"1.3.6.1.2.1.2.2.1.5.2" //Speed 
                }));


            SaveDevicesToJsonFile(filePath, devicesList);

            Console.WriteLine("Nuevo dispositivo agregado al archivo JSON.");
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

        public int selecttPortDevice(int device)
        {
            List<int> listOfDevice = getAllPort();

            return listOfDevice[device];
        }

    }//End class
}//End namespace

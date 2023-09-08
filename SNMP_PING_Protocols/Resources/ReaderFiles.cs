using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_PING_Protocols.Resources
{
    public class ReaderFiles
    {


        //Buildiers
        public ReaderFiles(){}


        //Methods
        public List<string> readerFilesOfDevices()
        {
            List<string> listOfDivices = new List<string>();

            //Se leera todo el archivo
            listOfDivices.Add("192.168.0.12");
            listOfDivices.Add("192.168.0.11");


            return listOfDivices;
        }
        
        public string deviceDisplay()
        {
            List<string> listOfDevices = readerFilesOfDevices();
            string stringOfDevice="";

            for (int i = 0; i < listOfDevices.Count; i++)
            {
                stringOfDevice += $"{i+1}) {listOfDevices[i]}\n";
            }

           return stringOfDevice;
        }
 
        //Devera ser un objeto y no un string
        public string selecttDevice(int device)
        {
            List<string> listOfDevice = readerFilesOfDevices();

            return listOfDevice[device + 1];
        }


    }//End class
}//End namespace

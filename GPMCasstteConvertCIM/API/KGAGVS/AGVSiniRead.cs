using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace GPMCasstteConvertCIM.API.KGAGVS
{
    internal class AGVSiniRead
    {
        public static string lastCarrierID;
        public  static void  ReadAGVSini(out string lastCarrierID)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("Status.ini");
            lastCarrierID = data["Rack3_1"]["Carrier_SerialID"];
        }
        public async static void checkinilastwrite()
        {
            while (true)
            {
                string iniFilePath = "Status.ini";
                string NewiniFilePath = @"";
                DateTime lastModifiedTime = File.GetLastWriteTime(iniFilePath);
                
                if (lastModifiedTime != File.GetLastWriteTime(iniFilePath))
                {
                    File.Copy(iniFilePath, NewiniFilePath, true);
                    ReadAGVSini(out lastCarrierID);
                }
                
            }
        }
       
    }
}

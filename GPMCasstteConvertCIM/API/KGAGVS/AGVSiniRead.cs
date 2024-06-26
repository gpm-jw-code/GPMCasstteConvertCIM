﻿using System;
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
        public async static Task ReadAGVSini(string EQ_Name, int Slot)
        {
            string EQ_NameInini = EQ_Name.ToUpper() + "_" + Slot.ToString();
            string iniFilePath = @"c:\CST\ini\Status.ini";
            string NewiniFilePath = @"d:\cimfile\Status.ini";
            string FilePath = @"d:\cimfile\";
            if (!Directory.Exists(FilePath)) { Directory.CreateDirectory(FilePath); }
            if (!File.Exists(NewiniFilePath))
            { using (FileStream fs = File.Create(NewiniFilePath)) ; }
            File.Copy(iniFilePath, NewiniFilePath, true);
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(NewiniFilePath);
            lastCarrierID = data["RACK3_1"]["LotID"]; //data[RACK3_1]["LotID"];
        }
        //public async static void checkinilastwrite()
        //{
        //    while (true)
        //    {
        //        string iniFilePath = "Status.ini";
        //        string NewiniFilePath = @"";
        //        DateTime lastModifiedTime = File.GetLastWriteTime(iniFilePath);

        //        if (lastModifiedTime != File.GetLastWriteTime(iniFilePath))
        //        {
        //            File.Copy(iniFilePath, NewiniFilePath, true);
        //            ReadAGVSini(out lastCarrierID);
        //        }

        //    }
        //}

    }
}

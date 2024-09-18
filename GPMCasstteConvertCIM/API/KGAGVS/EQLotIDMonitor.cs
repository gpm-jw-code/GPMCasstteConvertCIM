using IniParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.KGAGVS
{
    public class EQLotIDMonitor
    {
        //public const string STATUS_INI_FILE_PATH = @"C:\Users\USER\Documents";
        public const string STATUS_INI_FILE_PATH = "C://CST//ini//Status.ini";
        static FileSystemWatcher _fileWatcher;
        Dictionary<string, CarrierIDState> UnknownIDStored = new Dictionary<string, CarrierIDState>();
        public event EventHandler<CarrierIDState> OnUnknownIDInstalled;
        public async Task StartMonitor()
        {
            //ReadIni();
            InitIDStored();
            _ = Task.Run(() =>
            {
                string INI_Folder = Path.GetDirectoryName(STATUS_INI_FILE_PATH);
                string file = Path.GetFileName(STATUS_INI_FILE_PATH);
                _fileWatcher = new FileSystemWatcher(INI_Folder, "Status.ini");
                _fileWatcher.EnableRaisingEvents = true;
                _fileWatcher.IncludeSubdirectories = true;
                _fileWatcher.Changed += _fileWatcher_Changed;
            });
        }

        internal void InitIDStored()
        {
            Dictionary<string, string> lotIDs = GetLotIDsFromIni();

            foreach (var item in UnknownIDStored.Values)
            {
                item.CarrierIDHasTUNBegin -= Item_CarrierIDHasTUNBegin;
            }

            UnknownIDStored = lotIDs.ToDictionary(k => k.Key, k => new CarrierIDState { EQName = k.Key, CarrierID = k.Value });
            foreach (var item in UnknownIDStored.Values)
            {
                item.CarrierIDHasTUNBegin += Item_CarrierIDHasTUNBegin;
                if (item.IsUnknownID)
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(3000);
                        OnUnknownIDInstalled?.Invoke(this, item);
                    });

                }
            }
        }

        private void Item_CarrierIDHasTUNBegin(object? sender, string newCarrierID)
        {
            CarrierIDState _unknownCarrierIDState = (CarrierIDState)sender;
            OnUnknownIDInstalled?.Invoke(this, _unknownCarrierIDState);
        }

        private void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Task.Delay(500).ContinueWith(t =>
            {
                UnknownIDNotifier();
            });
        }

        private void UnknownIDNotifier()
        {
            Dictionary<string, string> lotIDs = GetLotIDsFromIni();
            if (lotIDs.Any())
            {
                foreach (var item in lotIDs)
                {
                    string eqName = item.Key;
                    string carrierID = item.Value;

                    if (UnknownIDStored.TryGetValue(eqName, out CarrierIDState idState))
                    {
                        idState.CarrierID = carrierID;
                    }

                }
            }
        }

        private Dictionary<string, string> GetLotIDsFromIni()
        {
            FileIniDataParser parser = new FileIniDataParser();
            IniParser.Model.IniData iniContext = parser.ReadFile(STATUS_INI_FILE_PATH);
            Dictionary<string, string> LotIDDict = iniContext.Sections.ToDictionary(section => section.SectionName, section => iniContext[section.SectionName]["LotID"]);

            return LotIDDict.ToDictionary(k => k.Key, k => k.Value == null ? "" : k.Value);
        }



        public class CarrierIDState
        {
            private string _CarrierID = "";
            public string EQName { get; set; } = "";
            public event EventHandler<string> CarrierIDHasTUNBegin;
            public string CarrierID
            {
                get => _CarrierID;
                set
                {
                    if (_CarrierID != value)
                    {
                        _CarrierID = value;
                        if (IsUnknownID)
                        {
                            CarrierIDHasTUNBegin?.Invoke(this, value);
                        }
                    }
                }
            }

            public bool IsUnknownID => _CarrierID.Contains("TUN");
        }



    }
}

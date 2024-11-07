using IniParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.KGAGVS
{
    public class EQLotIDMonitor
    {

        public class Configrations
        {
            public bool Enabled { get; set; } = false;
            public string STATUS_INI_FILE_PATH { get; set; } = "C://CST//ini//Status.ini";

            /// <summary>
            /// Key: KGS的設備名稱 , Value:派車顯示名稱
            /// </summary>
            public Dictionary<string, string> Monitor_Lot_Table { get; set; } = new Dictionary<string, string>()
            {
            };

        }

        public Configrations Config { get; set; } = new Configrations();

        public EQLotIDMonitor(Configrations config)
        {
            Config = config;
        }

        //public const string STATUS_INI_FILE_PATH = @"C:\Users\USER\Documents";
        static FileSystemWatcher _fileWatcher;
        Dictionary<string, CarrierIDState> UnknownIDStored = new Dictionary<string, CarrierIDState>();
        public event EventHandler<CarrierIDState> OnUnknownIDInstalled;
        public async Task StartMonitor()
        {
            if (!Config.Enabled)
                return;

            //ReadIni();
            InitIDStored();
            _ = Task.Run(() =>
            {
                string INI_Folder = Path.GetDirectoryName(Config.STATUS_INI_FILE_PATH);
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
                item.CarrierIDChanged -= Item_CarrierIDHasTUNBegin;
            }
            string _GetDisplayName(string eqName)
            {
                if (Config.Monitor_Lot_Table.TryGetValue(eqName, out string _displayName))
                    return _displayName;
                else
                    return eqName;
            }

            UnknownIDStored = lotIDs.ToDictionary(k => k.Key, k => new CarrierIDState { EQName = k.Key, DisplayName = _GetDisplayName(k.Key), CarrierID = k.Value });
            foreach (CarrierIDState item in UnknownIDStored.Values)
            {
                item.CarrierIDChanged += Item_CarrierIDHasTUNBegin;
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

        bool delayReadFileWaiting = false;

        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        private async void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                await semaphoreSlim.WaitAsync();
                if (delayReadFileWaiting)
                    return;
                delayReadFileWaiting = true;
                _ = Task.Factory.StartNew(async () =>
                {
                    await Task.Delay(1000);
                    _fileWatcher.EnableRaisingEvents = false;
                    UnknownIDNotifier();
                    _fileWatcher.EnableRaisingEvents = true;
                    delayReadFileWaiting = false;
                });

            }
            catch (Exception)
            {
            }
            finally
            {
                semaphoreSlim.Release();
            }

        }

        private void UnknownIDNotifier()
        {
            Dictionary<string, string> lotIDs = GetLotIDsFromIni();

            if (lotIDs.Any())
            {
                foreach (KeyValuePair<string, string> item in lotIDs)
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
            IniParser.Model.IniData iniContext = parser.ReadFile(Config.STATUS_INI_FILE_PATH);
            Dictionary<string, string> LotIDDict = iniContext.Sections.ToDictionary(section => section.SectionName, section => iniContext[section.SectionName]["LotID"]);
            Dictionary<string, string> lotIDs = LotIDDict.ToDictionary(k => k.Key, k => k.Value == null ? "" : k.Value);
            return lotIDs.Where(pair => Config.Monitor_Lot_Table.ContainsKey(pair.Key)).ToDictionary(k => k.Key, k => k.Value);

        }



        public class CarrierIDState
        {
            private string _CarrierID = "";
            public string EQName { get; set; } = "";

            public string DisplayName { get; set; } = "";

            public event EventHandler<string> CarrierIDChanged;
            public string CarrierID
            {
                get => _CarrierID;
                set
                {
                    if (_CarrierID != value)
                    {
                        _CarrierID = value;
                        CarrierIDChanged?.Invoke(this, value);
                    }
                }
            }

            public bool IsUnknownID => _CarrierID.Contains("TUN");
        }



    }
}

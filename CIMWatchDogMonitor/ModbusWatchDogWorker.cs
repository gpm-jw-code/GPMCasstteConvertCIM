using CIMWatchDogMonitor.CIM_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CIMWatchDogMonitor
{
    public class ModbusWatchDogWorker
    {

        public BindingList<ModbusWatchDog> WatchDogsList = new BindingList<ModbusWatchDog>();

        public async void StartWorkerAsync(ConnectionOptionsConfig CIMConnectionOptionConfig)
        {

            await Task.Delay(1);

            foreach (var PLC in CIMConnectionOptionConfig.PLCEQS)
            {
                foreach (Port port in PLC.Ports.Values)
                {
                    ModbusWatchDog watchDog = new ModbusWatchDog(port.PortID, port.ModbusServer_IP, port.ModbusServer_PORT);
                    WatchDogsList.Add(watchDog);
                    watchDog.StartAsync();
                }
            }

        }

        public class ModbusWatchDog : INotifyPropertyChanged
        {
            public string deviceName { get; private set; }
            public string ip { get; private set; }
            public int port { get; private set; }
            public bool alive { get; private set; } = false;
            private DateTime _lastDataRecieveTime;
            private DateTime _lastInputChangedTime;
            public string lastDataRecieveTime => _lastDataRecieveTime.ToString("yyyy/MM/dd HH:mm:ss");
            public string lastInputChangedTime => _lastInputChangedTime.ToString("yyyy/MM/dd HH:mm:ss");

            private bool[] Inputs = new bool[16];
            public string InputsStr => string.Join(",", Inputs.Select(bol => bol ? 1 : 0));

            ModbusClient modbusClient;

            public event PropertyChangedEventHandler PropertyChanged;

            public ModbusWatchDog(string deviceName, string ip, int port)
            {
                this.deviceName = deviceName;
                this.ip = ip;
                this.port = port;
            }

            internal async Task StartAsync()
            {
                modbusClient = new ModbusClient(this.port, this.ip);
                modbusClient.OnDataRecieved += ModbusClient_OnDataRecieved;
                modbusClient.OnInputChanged += ModbusClient_OnInputChanged;
                modbusClient.OnConnectionError += ModbusClient_OnConnectionError;
                modbusClient.OnConnectionReconnected += ModbusClient_OnConnectionReconnected;
                await modbusClient.RunAsync();
            }

            private void ModbusClient_OnConnectionReconnected(object sender, EventArgs e)
            {
                if (!alive)
                    WriteAbnormalLog($"{this.deviceName}-({ip}:{port}) Modbus Reconnceted!");
                alive = true;
                PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs("alive"), null, null);
                PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs("lastInputChangedTime"), null, null);
                PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs("lastDataRecieveTime"), null, null);
            }

            private void ModbusClient_OnConnectionError(object sender, EventArgs e)
            {
                if (alive)
                {
                    OnDisconeect?.Invoke(this, deviceName);
                    WriteAbnormalLog($"{this.deviceName}-({ip}:{port}) Modbus Disonncet");
                }
                alive = false;
                PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs("alive"), null, null);

            }

            private void ModbusClient_OnInputChanged(object sender, bool[] inputs)
            {
                this.Inputs = inputs;
                WriteIOChangeLog(deviceName, $"IO Changed To [{string.Join(",", inputs.Select(bol => bol ? 1 : 0))}]");

                _lastInputChangedTime = DateTime.Now;
                PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs("Inputs"), null, null);
                PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs("lastDataRecieveTime"), null, null);
                PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs("lastInputChangedTime"), null, null);
            }

            private void ModbusClient_OnDataRecieved(object sender, DateTime time)
            {
                _lastDataRecieveTime = time;
            }

            private static SemaphoreSlim writeLogSlim = new SemaphoreSlim(1, 1);

            internal static event EventHandler<string> OnDisconeect;

            private static async Task WriteAbnormalLog(string logText)
            {
                await writeLogSlim.WaitAsync().ConfigureAwait(false);
                try
                {
                    string folder = Path.Combine(Environment.CurrentDirectory, $@"Log\{DateTime.Now.ToString("yyyy-MM-dd")}");
                    Directory.CreateDirectory(folder);
                    string fileName = "Abnormal.log";
                    string logOut = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")}|{logText}";
                    using (StreamWriter _wirter = new StreamWriter(Path.Combine(folder, fileName), true))
                    {
                        _wirter.WriteLine(logOut);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    writeLogSlim.Release();
                }
            }

            private static async Task WriteIOChangeLog(string deviceName, string logText)
            {
                await writeLogSlim.WaitAsync().ConfigureAwait(false);
                try
                {
                    string folder = Path.Combine(Environment.CurrentDirectory, $@"Log\{DateTime.Now.ToString("yyyy-MM-dd")}");
                    Directory.CreateDirectory(folder);
                    string fileName = $"IO-{deviceName}.log";
                    string logOut = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")}|{logText}";
                    using (StreamWriter _wirter = new StreamWriter(Path.Combine(folder, fileName), true))
                    {
                        _wirter.WriteLine(logOut);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    writeLogSlim.Release();
                }
            }
        }

    }
}

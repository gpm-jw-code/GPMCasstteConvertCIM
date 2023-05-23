using GPMAPPBackgroundWoker;
using GPMCasstteConvertCIM.API.TcpSupport;
using Newtonsoft.Json;

string config_filepath = "./config.json";
clsConfig config = new clsConfig();
if (File.Exists(config_filepath))
    config = JsonConvert.DeserializeObject<clsConfig>(File.ReadAllText(config_filepath));

File.WriteAllText(config_filepath, JsonConvert.SerializeObject(config));

SystemAPI apiMiddleware = new SystemAPI(config);
apiMiddleware.Start();

Console.WriteLine("Ctrl + c to close...");

while (true)
{
    Thread.Sleep(1);
}

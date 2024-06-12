using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class ConfigLoader
{
    public static CanBusModel LoadConfiguration(string path)
    {
        var json = File.ReadAllText(path);
        var config = JsonConvert.DeserializeObject<ConfigModel>(json);
        return new CanBusModel
        {
            Commands = config.Commands,
            Statuses = config.Status
        };
    }
}

public class ConfigModel
{
    public List<Command> Commands { get; set; }
    public List<Status> Status { get; set; }
}

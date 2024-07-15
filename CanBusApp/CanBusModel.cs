public class CanBusModel
{
    public string NodeId { get; set; }
    public string Recons { get; set; }
    public string TxState { get; set; }
    public string TxFrames { get; set; }
    public string RxFrames { get; set; }
    public bool TxContinuous { get; set; }
    public bool AutoUpdate { get; set; }
    public List<Command> Commands { get; set; } = new List<Command>();
    public List<Status> Statuses { get; set; } = new List<Status>();
}

public class Command
{
    public string Label { get; set; }
    public string Type { get; set; }
    public List<string> Options { get; set; }
    public string DefaultValue { get; set; }
    public string ButtonText { get; set; }
}

public class Status
{
    public string Label { get; set; }
    public string Type { get; set; }
    public List<string> Options { get; set; }
    public string DefaultValue { get; set; }
    public string ButtonText { get; set; }
}

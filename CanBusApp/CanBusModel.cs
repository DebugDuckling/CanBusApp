public class CanBusModel
{
    public string NodeId { get; set; }
    public string State { get; set; }
    public int SendCount { get; set; }
    public int ReceiveCount { get; set; }
    public bool Continuously { get; set; }
    public bool Auto { get; set; }
    public List<Command> Commands { get; set; } = new List<Command>();
    public bool Mode { get; set; }
    public bool Enabler1 { get; set; }
    public bool Enabler2 { get; set; }
    public string Val1 { get; set; }
    public string Val2 { get; set; }
    public List<Status> Statuses { get; set; } = new List<Status>();

    // Update the data types
    public int Recons { get; set; }
    public string TxState { get; set; }
    public int TxFrames { get; set; }
    public int RxFrames { get; set; }
    public bool TxContinuous { get; set; }
    public bool AutoUpdate { get; set; }
}
public class Command
{
    public string Label { get; set; }
    public string Type { get; set; }
    public List<string> Options { get; set; }
    public string DefaultValue { get; set; }
    public string Code { get; set; } // Add this property
    public string ButtonText { get; set; } // Add this property
}

public class Status
{
    public string Label { get; set; }
    public string Type { get; set; }
    public List<string> Options { get; set; }
    public string DefaultValue { get; set; }
    public string Code { get; set; } // Add this property
    public string ButtonText { get; set; } // Add this property
}

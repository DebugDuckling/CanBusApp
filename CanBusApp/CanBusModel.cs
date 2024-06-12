using System.Collections.Generic;

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
}

public class Command
{
    public string Label { get; set; }
    public List<string> Options { get; set; }
    public string DefaultValue { get; set; }
}

public class Status
{
    public string Label { get; set; }
    public string DefaultValue { get; set; }
}

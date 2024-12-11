namespace TicketBridge.Client.Interfaces;

public interface ITicketBridgeIntegration {
    public TicketBridgeIntegrationType IntegrationType { get; }
    public string FaIcon { get; }
    public string DisplayText { get; }
    public string[] PropertyKeys { get; }
    public Dictionary<string, string> Properties { get; set; }
}
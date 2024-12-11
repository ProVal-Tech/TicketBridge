
namespace TicketBridge.Client.Models;

public class GitHubIntegration : IDatabaseEntity, ITicketBridgeIntegration {
    private readonly string _clientIdKey = "ClientId";
    private readonly string _installationIdKey = "InstallationId";
    private readonly string _orgKey = "Org";
    private readonly string _privateKeyKey = "PrivateKey";

    public int Id { get; set; }
    public TicketBridgeIntegrationType IntegrationType { get { return TicketBridgeIntegrationType.GitHub; } }
    public string FaIcon { get { return "fab fa-github"; } }
    public string DisplayText => $"Client ID: ...{new(Properties[_clientIdKey].TakeLast(4).ToArray())}";
    public string[] PropertyKeys => [_clientIdKey, _installationIdKey, _orgKey, _privateKeyKey];
    public Dictionary<string, string> Properties { get; set; }
    public GitHubIntegration() {
        Properties = [];
        foreach (string key in PropertyKeys) {
            Properties[key] = "";
        }
    }
    public string ClientId {
        get { return Properties[_clientIdKey]; }
        set { Properties[_clientIdKey] = value; }
    }

    public string InstallationId {
        get { return Properties[_installationIdKey]; }
        set { Properties[_installationIdKey] = value; }
    }

    public string Org {
        get { return Properties[_orgKey]; }
        set { Properties[_orgKey] = value; }
    }

    public string PrivateKey {
        get { return Properties[_privateKeyKey]; }
        set { Properties[_privateKeyKey] = value; }
    }
}
namespace TicketBridge.Client.Interfaces;

public interface IIntegrationService {
    Task<IEnumerable<ITicketBridgeIntegration>> GetIntegrationsAsync();
    Task<ITicketBridgeIntegration> GetIntegrationAsync(int id);
    Task<ITicketBridgeIntegration> AddIntegrationAsync(ITicketBridgeIntegration integration);
    Task<ITicketBridgeIntegration> UpdateIntegrationAsync(ITicketBridgeIntegration integration);
    Task DeleteIntegrationAsync(int id);
}

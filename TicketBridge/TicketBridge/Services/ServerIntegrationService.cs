using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TicketBridge.Services;

public class ServerIntegrationService : IIntegrationService {
    public Task<ITicketBridgeIntegration> GetIntegrationAsync(int id) {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<ITicketBridgeIntegration>> GetIntegrationsAsync() {
        throw new NotImplementedException();
    }

    public async Task<ITicketBridgeIntegration> AddIntegrationAsync(ITicketBridgeIntegration integration) {
        TicketBridgeContext context = new();
        EntityEntry result = integration switch {
            GitHubIntegration gitHubIntegration => await context.GitHubIntegrations.AddAsync(gitHubIntegration),
            _ => throw new InvalidOperationException("Invalid integration type"),
        };
        await context.SaveChangesAsync();
        return (ITicketBridgeIntegration)result.Entity;
    }

    public Task DeleteIntegrationAsync(int id) {
        throw new NotImplementedException();
    }

    public Task<ITicketBridgeIntegration> UpdateIntegrationAsync(ITicketBridgeIntegration integration) {
        throw new NotImplementedException();
    }
}

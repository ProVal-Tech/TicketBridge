
using System.Net.Http.Json;

namespace TicketBridge.Client.Services;

public class ClientIntegrationService(HttpClient http) : IIntegrationService {
    public async Task<ITicketBridgeIntegration> AddIntegrationAsync(ITicketBridgeIntegration integration) {
        HttpResponseMessage response = await http.PostAsJsonAsync("api/integrations", integration);
        if (!response.IsSuccessStatusCode) {
            throw new InvalidOperationException($"Failed to add integration. Status code: {response.StatusCode}");
        }
        return await response.Content.ReadFromJsonAsync<ITicketBridgeIntegration>()
            ?? throw new InvalidOperationException("Failed to add integration");
    }

    public Task DeleteIntegrationAsync(int id) {
        throw new NotImplementedException();
    }

    public Task<ITicketBridgeIntegration> GetIntegrationAsync(int id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ITicketBridgeIntegration>> GetIntegrationsAsync() {
        throw new NotImplementedException();
    }

    public Task<ITicketBridgeIntegration> UpdateIntegrationAsync(ITicketBridgeIntegration integration) {
        throw new NotImplementedException();
    }
}

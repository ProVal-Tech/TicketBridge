
namespace TicketBridge.Client.Services;

public class ClientGitHubService(HttpClient http) : IGitHubService {
    public async Task<string> GetAppName() {
        return await http.GetStringAsync("api/github/appname");
    }
}

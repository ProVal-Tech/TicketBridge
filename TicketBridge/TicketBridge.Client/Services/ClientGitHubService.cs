
using System.Net.Http.Json;

namespace TicketBridge.Client.Services;

public class ClientGitHubService(HttpClient http) : IGitHubService {
    public async Task<string> GetAppName() {
        return await http.GetStringAsync("api/github/appname");
    }

    public async Task<IEnumerable<GitHubProjectV2>> GetOrgProjects() {
        return await http.GetFromJsonAsync<IEnumerable<GitHubProjectV2>>("api/github/orgprojects")
            ?? throw new InvalidOperationException("Failed to fetch projects");
    }
}

namespace TicketBridge.Client.Interfaces;

public interface IGitHubService {
    Task<string> GetAppName();
    Task<IEnumerable<GitHubProjectV2>> GetOrgProjects();
}

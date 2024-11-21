namespace TicketBridge.Client.Services;

public interface IGitHubService {
    Task<string> GetAppName();
}

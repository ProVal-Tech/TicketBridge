namespace TicketBridge.Client.Models;

public interface IGitHubUpdatable {
    bool ViewerCanUpdate { get; set; }
}

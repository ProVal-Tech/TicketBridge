namespace TicketBridge.Client.Models;

public interface IGitHubDeletable {
    bool ViewerCanDelete { get; set; }
}

namespace TicketBridge.Client.Models;

public interface IGitHubClosable {
    bool? Closed { get; set; }
    DateTime? ClosedAt { get; set; }
    bool? ViewerCanClose { get; set; }
    bool? ViewerCanReopen { get; set; }
}

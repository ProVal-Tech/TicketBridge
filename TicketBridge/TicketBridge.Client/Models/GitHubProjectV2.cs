namespace TicketBridge.Client.Models;

public class GitHubProjectV2 : IGitHubNode, IGitHubClosable, IGitHubUpdatable {
    public string Id { get; set; } = null!;
    public bool Closed { get; set; }
    public DateTime ClosedAt { get; set; }
    public bool ViewerCanClose { get; set; }
    public bool ViewerCanReopen { get; set; }
    public bool ViewerCanUpdate { get; set; }
}

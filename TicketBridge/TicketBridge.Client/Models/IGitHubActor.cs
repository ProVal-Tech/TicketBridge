namespace TicketBridge.Client.Models;

public interface IGitHubActor {
    Uri? AvatarUrl { get; set; }
    string? Login { get; set; }
    Uri? ResourcePath { get; set; }
    Uri? Url { get; set; }
}

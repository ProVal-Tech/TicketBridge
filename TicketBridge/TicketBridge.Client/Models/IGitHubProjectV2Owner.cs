namespace TicketBridge.Client.Models;

public interface IGitHubProjectV2Owner {
    string? Id { get; set; }
    IEnumerable<GitHubProjectV2>? ProjectsV2 { get; set; }
}

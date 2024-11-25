

namespace TicketBridge.Client.Models;

public class GitHubUser : IGitHubActor, IGitHubNode, IGitHubProjectV2Owner {
    public Uri? AvatarUrl { get; set; }
    public string? Login { get; set; }
    public Uri? ResourcePath { get; set; }
    public Uri? Url { get; set; }
    public string? Id { get; set; }
    public IEnumerable<GitHubProjectV2>? ProjectsV2 { get; set; }
}

namespace TicketBridge.Client.Models;

public class GitHubLabel : IGitHubNode {
    public string? Color { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Description { get; set; }
    public string? Id { get; set; }
    public bool? IsDefault { get; set; }
    public IEnumerable<GitHubIssue>? Issues { get; set; }
    public string? Name { get; set; }
    public IEnumerable<GitHubPullRequest>? PullRequests { get; set; }
    public GitHubRepository? Repository { get; set; }
    public Uri? ResourcePath { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Uri? Url { get; set; }
}

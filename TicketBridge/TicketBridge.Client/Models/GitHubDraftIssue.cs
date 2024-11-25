namespace TicketBridge.Client.Models;

public class GitHubDraftIssue : IGitHubNode, IGitHubProjectV2ItemContent {
    public IEnumerable<GitHubUser>? Assignees { get; set; }
    public string? Body { get; set; }
    public string? BodyHtml { get; set; }
    public string? BodyText { get; set; }
    public DateTime? CreatedAt { get; set; }
    public IGitHubActor? Creator { get; set; }
    public string? Id { get; set; }
    public IEnumerable<GitHubProjectV2Item>? ProjectV2Items { get; set; }
    public IEnumerable<GitHubProjectV2>? ProjectsV2 { get; set; }
    public string? Title { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

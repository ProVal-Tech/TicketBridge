namespace TicketBridge.Client.Models;

public class GitHubUserContentEdit : IGitHubNode {
    public DateTime? CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public IGitHubActor? DeletedBy { get; set; }
    public string? Diff { get; set; }
    public DateTime? EditedAt { get; set; }
    public IGitHubActor? Editor { get; set; }
    public string? Id { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

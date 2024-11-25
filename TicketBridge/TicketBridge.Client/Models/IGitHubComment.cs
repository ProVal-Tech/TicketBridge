namespace TicketBridge.Client.Models;

public interface IGitHubComment {
    IGitHubActor? Author { get; set; }
    GitHubCommentAuthorAssociation? AuthorAssociation { get; set; }
    string? Body { get; set; }
    string? BodyHtml { get; set; }
    string? BodyText { get; set; }
    DateTime? CreatedAt { get; set; }
    bool? CreatedViaEmail { get; set; }
    IGitHubActor? Editor { get; set; }
    string? Id { get; set; }
    bool? IncludesCreatedEdit { get; set; }
    DateTime? LastEditedAt { get; set; }
    DateTime? PublishedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    IEnumerable<GitHubUserContentEdit>? UserContentEdits { get; set; }
    bool? ViewerDidAuthor { get; set; }
}

namespace TicketBridge.Client.Models;

public class GitHubProjectV2IterationField : IGitHubProjectV2FieldCommon, IGitHubNode {
    //TODO: Finish this class
    public DateTime CreatedAt { get; set; }
    public GitHubProjectV2FieldType DataType { get; set; }
    public int DatabaseId { get; set; }
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public GitHubProjectV2 Project { get; set; } = null!;
    public DateTime UpdatedAt { get; set; }
}

namespace TicketBridge.Client.Models;

public interface IGitHubAssignable {
    IEnumerable<GitHubUser>? Assignees { get; set; }
}

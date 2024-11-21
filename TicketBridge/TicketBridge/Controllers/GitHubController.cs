using Microsoft.AspNetCore.Mvc;
using TicketBridge.Client.Services;
using TicketBridge.Services;

namespace TicketBridge.Controllers;
public class GitHubController() : Controller {
    public IActionResult Index() {
        return View();
    }

    [HttpGet("api/github/appname")]
    public async Task<IActionResult> GetAppName([FromServices] IGitHubService gitHubService) {
        return Ok(await gitHubService.GetAppName());
    }
}

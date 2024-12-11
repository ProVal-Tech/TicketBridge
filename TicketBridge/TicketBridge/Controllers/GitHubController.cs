using Microsoft.AspNetCore.Mvc;

namespace TicketBridge.Controllers;
public class GitHubController() : Controller {
    public IActionResult Index() {
        return View();
    }

    [HttpGet("api/github/appname")]
    public async Task<IActionResult> GetAppName([FromServices] IGitHubService gitHubService) {
        return Ok(await gitHubService.GetAppName());
    }

    [HttpGet("api/github/orgprojects")]
    public async Task<IActionResult> GetOrgProjects([FromServices] IGitHubService gitHubService) {
        return Ok(await gitHubService.GetOrgProjects());
    }
}

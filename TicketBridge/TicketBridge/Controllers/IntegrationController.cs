using Microsoft.AspNetCore.Mvc;

namespace TicketBridge.Controllers;
public class IntegrationController : Controller {
    public IActionResult Index() {
        return View();
    }

    [HttpPost("api/integrations")]
    public async Task<IActionResult> AddIntegrationAsync(
        [FromBody] ITicketBridgeIntegration integration,
        [FromServices] IIntegrationService integrationService) {
        try {
            return Ok(await integrationService.AddIntegrationAsync(integration));
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
}

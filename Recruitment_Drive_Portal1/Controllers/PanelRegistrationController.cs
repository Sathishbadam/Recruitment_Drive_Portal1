using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment_Drive_Portal1.Application.Services;
using Recruitment_Drive_Portal1.Domain.Models;

namespace Recruitment_Drive_Portal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelRegistrationController : ControllerBase
    {
        private readonly PanelRegistrationService _service;

        public PanelRegistrationController(PanelRegistrationService service)
        {

            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PanelRegistration(RegisterPanel panel)
        {
            var paneldetails = await _service.RegisterPanel(panel);
            return Ok(paneldetails);
        }
    }
}

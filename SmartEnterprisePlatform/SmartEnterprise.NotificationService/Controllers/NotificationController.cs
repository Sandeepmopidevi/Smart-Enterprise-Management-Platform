using Microsoft.AspNetCore.Mvc;
using SmartEnterprise.NotificationService.Models;
using SmartEnterprise.NotificationService.Services;

namespace SmartEnterprise.NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly EmailService _emailService;

        public NotificationController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            await _emailService.SendEmailAsync(request);
            return Ok("📧 Email Sent Successfully!");
        }
    }
}

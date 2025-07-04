using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartEnterprise.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        // 🔓 Public - No auth needed
        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("🌐 This is a public endpoint.");
        }

        // 🔐 Requires any authenticated user
        [HttpGet("user")]
        [Authorize]
        public IActionResult Authenticated()
        {
            var userEmail = User.Identity?.Name ?? "Unknown";
            return Ok($"✅ Hello, {userEmail}. You are authenticated.");
        }

        // 👑 Requires Admin role
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return Ok("👑 Welcome, Admin. This is a protected admin-only endpoint.");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly AuthServiceClient _authService;

    public LoginController(AuthServiceClient authService)
    {
        _authService = authService;
    }

    [HttpGet("verifica")]
    public async Task<IActionResult> VerificarEmail([FromQuery] string email)
    {
        bool existe = await _authService.ValidarEmailAsync(email);
        return Ok(new { email, existe });
    }
}

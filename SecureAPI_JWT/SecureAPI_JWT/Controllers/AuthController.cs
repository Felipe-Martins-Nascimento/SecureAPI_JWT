using Microsoft.AspNetCore.Mvc;
using SecureAPI_JWT.DTOs;
using SecureAPI_JWT.Services.AuthService;

namespace SecureAPI_JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthInterface _authInterface;

    public AuthController(IAuthInterface authInterface)
    {
        _authInterface = authInterface;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UsuarioLoginDTO usuarioLogin)
    {
        var resposta = await _authInterface.Login(usuarioLogin);
        return Ok(resposta);
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UsuarioCriacaoDTO usuarioRegister)
    {
        var resposta = await _authInterface.Registrar(usuarioRegister);
        return Ok(resposta);
    }
}

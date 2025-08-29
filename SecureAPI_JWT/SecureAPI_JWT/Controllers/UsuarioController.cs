using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureAPI_JWT.Models;

namespace SecureAPI_JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ActionResult<Response<string>> GetUsuario()
    {
        var response = new Response<string>();
        response.Mensagem = "Acessei";

        return Ok(response);
    }
}

using SecureAPI_JWT.DTOs;
using SecureAPI_JWT.Models;

namespace SecureAPI_JWT.Services.AuthService;

public interface IAuthInterface
{
    Task<Response<UsuarioCriacaoDTO>> Registrar(UsuarioCriacaoDTO usuarioRegistro);
    Task<Response<string>> Login(UsuarioLoginDTO usuarioLogin);
    bool VerificaExistentest(UsuarioCriacaoDTO usuarioRegistro);
}

using SecureAPI_JWT.Models;

namespace SecureAPI_JWT.Services.SenhaService;

public interface ISenhaInterface
{
    bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt);
    string CriarToken(UsuarioModel usuario);
    void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
}

using Microsoft.IdentityModel.Tokens;
using SecureAPI_JWT.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SecureAPI_JWT.Services.SenhaService;

public class SenhaService : ISenhaInterface
{
    private readonly IConfiguration _config;

    public SenhaService(IConfiguration config)
    {
        _config = config;
    }

    public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }
    }

    public bool VerificaSenhaHash(string senha, byte[] senhaHashArmazenado, byte[] senhaSaltArmazenado)
    {
        using (var hmac = new HMACSHA512(senhaSaltArmazenado))
        {
            var senhaHashComputado = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return senhaHashComputado.SequenceEqual(senhaHashArmazenado);
        }
    }

    public string CriarToken(UsuarioModel usuario)
    {
        var claims = new List<Claim>
        {
            new Claim("Cargo", usuario.Cargo.ToString()),
            new Claim("Email", usuario.Email),
            new Claim("Username", usuario.Usuario)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(2),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}

using Microsoft.EntityFrameworkCore;
using SecureAPI_JWT.Context;
using SecureAPI_JWT.DTOs;
using SecureAPI_JWT.Models;
using SecureAPI_JWT.Services.SenhaService;

namespace SecureAPI_JWT.Services.AuthService;

public class AuthService : IAuthInterface
{
    private readonly AppDbContext _context;
    private readonly ISenhaInterface _senhaInterface;

    public AuthService(AppDbContext context, ISenhaInterface senhaInterface)
    {
        _context = context;
        _senhaInterface = senhaInterface;
    }

    public async Task<Response<UsuarioCriacaoDTO>> Registrar(UsuarioCriacaoDTO usuarioRegistro)
    {
        Response<UsuarioCriacaoDTO> respostaServico = new Response<UsuarioCriacaoDTO>();
        try
        {
            if (VerificaExistentest(usuarioRegistro))
            {
                respostaServico.Dados = null;
                respostaServico.Status = false;
                respostaServico.Mensagem = "Email/Usuário já cadastrados!";
                return respostaServico;
            }

            _senhaInterface.CriarSenhaHash(usuarioRegistro.Senha, out byte[] senhaHash, out byte[] senhaSalt);

            var usuario = new UsuarioModel
            {
                Usuario = usuarioRegistro.Usuario,
                Email = usuarioRegistro.Email, 
                Cargo = usuarioRegistro.Cargo,
                SenhaHash = senhaHash,
                SenhaSalt = senhaSalt
            };

            _context.Add(usuario);
            await _context.SaveChangesAsync();

            respostaServico.Mensagem = "Usuário criado com sucesso!";
        }
        catch (Exception ex)
        {
            respostaServico.Dados = null;
            respostaServico.Mensagem = ex.Message; 
            respostaServico.Status = false;
        }
        return respostaServico;
    }

    public async Task<Response<string>> Login(UsuarioLoginDTO usuarioLogin)
    {
        Response<string> respostaServico = new Response<string>();
        try
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == usuarioLogin.Email);

            if (usuario == null || !_senhaInterface.VerificaSenhaHash(usuarioLogin.Senha, usuario.SenhaHash, usuario.SenhaSalt))
            {
                respostaServico.Dados = null;
                respostaServico.Mensagem = "Credenciais inválidas!";
                respostaServico.Status = false;
                return respostaServico;
            }

            var token = _senhaInterface.CriarToken(usuario);

            respostaServico.Dados = token;
            respostaServico.Mensagem = "Usuário logado com sucesso!";
            respostaServico.Status = true;
        }
        catch (Exception ex)
        {
            respostaServico.Dados = null;
            respostaServico.Mensagem = ex.Message; 
            respostaServico.Status = false;
        }
        return respostaServico;
    }

    public bool VerificaExistentest(UsuarioCriacaoDTO usuarioRegistro)
    {
        var usuario = _context.Usuario.FirstOrDefault(u => u.Email == usuarioRegistro.Email || u.Usuario == usuarioRegistro.Usuario);
        return usuario != null; 
    }
}

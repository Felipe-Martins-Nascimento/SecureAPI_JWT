using SecureAPI_JWT.Enum;
using System.ComponentModel.DataAnnotations;

namespace SecureAPI_JWT.DTOs;

public class UsuarioCriacaoDTO
{
    [Required(ErrorMessage = "O campo usuário é obrigatório")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "O campo email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public string Senha { get; set; }

    [Compare("Senha", ErrorMessage = "Senhas não coincidem!")]
    public string ConfirmaSenha { get; set; }

    [Required(ErrorMessage = "O campo cargo é obrigatório")]
    public CargoEnum Cargo { get; set; }
}

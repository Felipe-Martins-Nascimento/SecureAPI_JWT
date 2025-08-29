using System.ComponentModel.DataAnnotations;

namespace SecureAPI_JWT.DTOs;

public class UsuarioLoginDTO
{
    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; }
}

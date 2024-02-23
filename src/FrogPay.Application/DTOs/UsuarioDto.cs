using System.ComponentModel.DataAnnotations;

namespace src.FrogPay.Application.DTOs;

public record UsuarioDto
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Compare("Senha", ErrorMessage = "Senhas não coincidem")]
    public string ConfirmaSenha { get; set; }   
}
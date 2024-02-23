using System.ComponentModel.DataAnnotations;

namespace src.FrogPay.Application.DTOs;

public record LoginDto
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Senha { get; set; }
}
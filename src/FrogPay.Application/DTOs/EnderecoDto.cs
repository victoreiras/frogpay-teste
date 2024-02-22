using System.ComponentModel.DataAnnotations;

namespace src.FrogPay.Application.DTOs;

public record EnderecoDto
{
    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(2)]
    public string UfEstado { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(500)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(500)]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(500)]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(20)]
    public string Numero { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(500)]
    public string Complemento { get; set; }
}
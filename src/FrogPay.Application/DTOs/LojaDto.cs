using System.ComponentModel.DataAnnotations;

namespace src.FrogPay.Application.DTOs;

public record LojaDto
{
    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(500)]
    public string NomeFantasia { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(500)]
    public string RazaoSocial { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(50)]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    public DateTime DataAbertura { get; set; }
}
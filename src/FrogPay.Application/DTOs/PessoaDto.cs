using System.ComponentModel.DataAnnotations;

namespace src.FrogPay.Application.DTOs;

public record PessoaDto
{
    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(500)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MaxLength(50)]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    public DateTime DataNascimento { get; set; }

    public EnderecoDto Endereco { get; set; }

    public LojaDto Loja { get; set; }

    public DadosBancariosDto DadosBancarios { get; set; }

}
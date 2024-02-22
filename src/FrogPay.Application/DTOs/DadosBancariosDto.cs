using System.ComponentModel.DataAnnotations;

namespace src.FrogPay.Application.DTOs;

    public record DadosBancariosDto
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string CodigoBanco { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Conta { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string DigitoConta { get; set; }
    }
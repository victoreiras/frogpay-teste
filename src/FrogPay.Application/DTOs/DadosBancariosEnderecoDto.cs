namespace src.FrogPay.Application.DTOs;

public record DadosBancariosEnderecoDto
{
    public string CodigoBanco { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public string DigitoConta { get; set; }        

    public string UfEstado { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
}

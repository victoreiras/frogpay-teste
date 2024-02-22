namespace src.FrogPay.Domain.Entities;
public class DadosBancarios
{
    public DadosBancarios(string codigoBanco, string agencia, string conta, string digitoConta)
    {
        CodigoBanco = codigoBanco;
        Agencia = agencia;
        Conta = conta;
        DigitoConta = digitoConta;
    }

    public Guid Id { get; set; }
    public string CodigoBanco { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public string DigitoConta { get; set; }
    public Guid IdPessoa { get; set; }
    public Pessoa Pessoa { get; set; }
}

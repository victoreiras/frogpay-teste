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

    public Guid Id { get; private set; }
    public string CodigoBanco { get; private set; }
    public string Agencia { get; private set; }
    public string Conta { get; private set; }
    public string DigitoConta { get; private set; }
    public Guid IdPessoa { get; private set; }
    public Pessoa Pessoa { get; private set; }
}

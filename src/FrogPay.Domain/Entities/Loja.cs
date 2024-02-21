namespace src.FrogPay.Domain.Entities;

public class Loja
{
    public Loja(string nomeFantasia, string razaoSocial, string cnpj)
    {
        NomeFantasia = nomeFantasia;
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        DataAbertura = DateTime.Now;
    }

    public int Id { get; private set; }
    public string NomeFantasia { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Cnpj { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public Pessoa Pessoa { get; private set; }
}

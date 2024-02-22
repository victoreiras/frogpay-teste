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

    public Guid Id { get; set; }
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public DateTime DataAbertura { get; set; }
    public Pessoa Pessoa { get; set; }
    public Guid IdPessoa { get; set; }
}

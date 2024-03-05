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

    public Guid Id { get; private set; }
    public string NomeFantasia { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Cnpj { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public Pessoa Pessoa { get; private set; }
    public Guid IdPessoa { get; private set; }

    public void Atualizar(Loja loja)
    {
        NomeFantasia = loja.NomeFantasia;
        RazaoSocial = loja.RazaoSocial;
        Cnpj = loja.Cnpj;
        DataAbertura = loja.DataAbertura;
    }
}

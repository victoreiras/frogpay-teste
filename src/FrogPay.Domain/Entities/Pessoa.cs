namespace src.FrogPay.Domain.Entities;

public class Pessoa
{
    public Pessoa(string nome, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Ativo = true;
        DataCriacao = DateTime.Now;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; }
    public Endereco Endereco { get; set; }
    public Loja Loja { get; set; }
    public DadosBancarios DadosBancarios { get; set; }
}

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

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public Endereco Endereco { get; set; }
    public Loja Loja { get; set; }
    // public DadosBancarios DadosBancarios { get; private set; }
}

namespace src.FrogPay.Domain.Entities;

public class Endereco
{
    public Endereco(string ufEstado, string cidade, string bairro, string logradouro, string numero, string complemento)
    {
        UfEstado = ufEstado;
        Cidade = cidade;
        Bairro = bairro;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
    }
    
    public int Id { get; private set; }
    public string UfEstado { get; private set; }
    public string Cidade { get; private set; }
    public string Bairro { get; private set; }
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public Pessoa Pessoa { get; private set; }
}
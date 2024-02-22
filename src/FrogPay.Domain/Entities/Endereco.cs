using System;

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
    
    public Guid Id { get; set; }
    public string UfEstado { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public Guid IdPessoa { get; set; }
    public Pessoa Pessoa { get; set; }
}
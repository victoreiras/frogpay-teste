using src.FrogPay.Domain.Entities;
using src.FrogPay.Domain.Interfaces;
using src.FrogPay.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using src.FrogPay.Application.DTOs;

namespace src.FrogPay.Infrastructure.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly ApplicationDbContext _db;

    public PessoaRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public void CadastrarPessoa(Pessoa pessoa)
    {
        _db.Pessoas.Add(pessoa);
        _db.SaveChanges();
    }

    public void EditarPessoa(Pessoa pessoa)
    {
        _db.Pessoas.Update(pessoa);
        _db.SaveChanges();
    }

    public Pessoa ObterPessoaPorId(Guid id)
    {
        return _db.Pessoas
            .Include(q => q.Endereco)
            .Include(q => q.DadosBancarios)
            .Include(q => q.Loja)
            .FirstOrDefault(p => p.Id == id);
    }

    public DadosBancariosEnderecoDto ObterDadosBancarios(Guid id)
    {
        var resultado = _db.Pessoas
            .Where(x => x.Id == id)
            .Select(q => 
            new DadosBancariosEnderecoDto 
            {
                CodigoBanco = q.DadosBancarios.CodigoBanco,
                Agencia = q.DadosBancarios.Agencia,
                Conta = q.DadosBancarios.Conta,
                DigitoConta = q.DadosBancarios.DigitoConta,
                UfEstado = q.Endereco.UfEstado,
                Cidade = q.Endereco.Cidade,
                Bairro = q.Endereco.Bairro,
                Logradouro = q.Endereco.Logradouro,
                Numero = q.Endereco.Numero,
                Complemento = q.Endereco.Complemento
            })
            .FirstOrDefault(); 

        return resultado;       
    }

    public EnderecoDto ObterEndereco(string nomePessoa)
    {
        var resultado = _db.Pessoas
            .Where(q => q.Nome.Contains(nomePessoa))
            .Select(x =>
            new EnderecoDto
            {
                UfEstado = x.Endereco.UfEstado,
                Cidade = x.Endereco.Cidade,
                Bairro = x.Endereco.Bairro,
                Logradouro = x.Endereco.Logradouro,
                Numero = x.Endereco.Numero,
                Complemento = x.Endereco.Complemento
            })
            .FirstOrDefault();

        return resultado;
    }
}
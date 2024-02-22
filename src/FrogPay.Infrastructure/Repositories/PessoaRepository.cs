using src.FrogPay.Domain.Entities;
using src.FrogPay.Domain.Interfaces;
using src.FrogPay.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
}
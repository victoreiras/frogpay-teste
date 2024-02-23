using src.FrogPay.Domain.Entities;
using src.FrogPay.Domain.Interfaces;
using src.FrogPay.Infrastructure.Data;

namespace src.FrogPay.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _db;

    public UsuarioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Usuario ObterUsuario(string usuario)
    {
        return _db.Usuarios.FirstOrDefault(q => q.UserName == usuario);
    }

    public void Registrar(Usuario usuario)
    {
        _db.Add(usuario);
        _db.SaveChanges();
    }
}

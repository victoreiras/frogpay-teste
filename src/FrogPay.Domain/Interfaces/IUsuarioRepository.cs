using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Domain.Interfaces;

public interface IUsuarioRepository
{
    void Registrar(Usuario usuario);
    Usuario ObterUsuario(string email);
}
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Domain.Interfaces;

public interface ISenhaService
{
    void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    bool VerificaSenhaHashValida(string senha, byte[] senhaHash, byte[] senhaSalt);
    string GerarToken(Usuario usuario);
}
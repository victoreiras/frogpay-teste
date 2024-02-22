using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Domain.Interfaces;

public interface IPessoaRepository
{
    void CadastrarPessoa(Pessoa pessoa);
}
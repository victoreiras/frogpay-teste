using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Domain.Interfaces;

public interface IPessoaRepository
{
    void CadastrarPessoa(Pessoa pessoa);
    void EditarPessoa(Pessoa pessoa);

    Pessoa ObterPessoaPorId(Guid id);
}
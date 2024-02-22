using src.FrogPay.Application.DTOs;

namespace src.FrogPay.Application.Interfaces;
public interface IPessoaService
{
    ServiceResponse<PessoaDto> CadastrarPessoa(PessoaDto pessoaDto);
}
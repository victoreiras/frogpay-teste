using src.FrogPay.Application.DTOs;

namespace src.FrogPay.Application.Interfaces;
public interface IPessoaService
{
    ServiceResponse<PessoaCriacaoDto> CadastrarPessoa(PessoaCriacaoDto pessoaDto);
    ServiceResponse<PessoaEdicaoDto> EditarPessoa (PessoaEdicaoDto pessoaDto);
}
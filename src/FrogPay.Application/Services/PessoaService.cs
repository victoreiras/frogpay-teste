using AutoMapper;
using src.FrogPay.Application.DTOs;
using src.FrogPay.Application.Interfaces;
using src.FrogPay.Domain.Entities;
using src.FrogPay.Domain.Interfaces;

namespace src.FrogPay.Application.Services;
public class PessoaService : IPessoaService
{
    private readonly IMapper _mapper;
    private readonly IPessoaRepository _pessoaRepository;
    public PessoaService(IMapper mapper, IPessoaRepository pessoaRepository)
    {
        _mapper = mapper;
        _pessoaRepository = pessoaRepository;
    }

    public ServiceResponse<PessoaDto> CadastrarPessoa(PessoaDto pessoaDto)
    {
        var serviceResponse = new ServiceResponse<PessoaDto>();

        try
        {
            if ((pessoaDto is null))
            {
                serviceResponse.Mensagem = "Parâmetros inválidos";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var pessoa = new Pessoa(pessoaDto.Nome, pessoaDto.Cpf, pessoaDto.DataNascimento);
            //var pessoa = _mapper.Map<Pessoa>(PessoaDto);
            _pessoaRepository.CadastrarPessoa(pessoa);
            
            serviceResponse.Dados = pessoaDto;
            serviceResponse.Mensagem = "Pessoa criada com sucesso!";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}
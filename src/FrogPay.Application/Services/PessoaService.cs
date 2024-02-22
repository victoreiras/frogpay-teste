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
            if (pessoaDto is null)
            {
                serviceResponse.Mensagem = "Parâmetros inválidos";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var pessoa = new Pessoa(
                pessoaDto.Nome, 
                pessoaDto.Cpf, 
                pessoaDto.DataNascimento);

            var endereco = new Endereco(
                pessoaDto.Endereco.UfEstado, 
                pessoaDto.Endereco.Cidade, 
                pessoaDto.Endereco.Bairro,
                pessoaDto.Endereco.Logradouro,
                pessoaDto.Endereco.Numero,
                pessoaDto.Endereco.Complemento);

            var loja = new Loja(
                pessoaDto.Loja.NomeFantasia,
                pessoaDto.Loja.RazaoSocial,
                pessoaDto.Loja.Cnpj);
            
            pessoa.Endereco = endereco;
            pessoa.Loja = loja;

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

    public ServiceResponse<PessoaDto> EditarPessoa(PessoaDto pessoaDto)
    {
         var serviceResponse = new ServiceResponse<PessoaDto>();

        try
        {
            if (pessoaDto is null)
            {
                serviceResponse.Mensagem = "Lista não pode ser nula.";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaDto);
            _pessoaRepository.EditarPessoa(pessoa);

            serviceResponse.Dados = pessoaDto;
            serviceResponse.Mensagem = "Pessoa atualizada com sucesso!";
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}
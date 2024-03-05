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

    public ServiceResponse<PessoaCriacaoDto> CadastrarPessoa(PessoaCriacaoDto pessoaCriacaoDto)
    {
        var serviceResponse = new ServiceResponse<PessoaCriacaoDto>();

        try
        {
            if (pessoaCriacaoDto is null)
            {
                serviceResponse.Mensagem = "Parâmetros inválidos";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaCriacaoDto);
            _pessoaRepository.CadastrarPessoa(pessoa);
            
            serviceResponse.Dados = pessoaCriacaoDto;
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

    public ServiceResponse<PessoaEdicaoDto> EditarPessoa(PessoaEdicaoDto pessoaEdicaoDto)
    {
         var serviceResponse = new ServiceResponse<PessoaEdicaoDto>();

        try
        {
            var pessoa = _pessoaRepository.ObterPessoaPorId(pessoaEdicaoDto.Id);

            if (pessoa is null)
            {
                serviceResponse.Mensagem = "Pessoa não encontrada.";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var pessoaEdicao = _mapper.Map<Pessoa>(pessoaEdicaoDto);
            
            pessoa.DadosBancarios.Atualizar(pessoaEdicao.DadosBancarios);
            pessoa.Loja.Atualizar(pessoaEdicao.Loja);
            pessoa.Endereco.Atualizar(pessoaEdicao.Endereco);
            pessoa.Atualizar(pessoaEdicao);

            _pessoaRepository.EditarPessoa(pessoa);

            serviceResponse.Dados = pessoaEdicaoDto;
            serviceResponse.Mensagem = "Pessoa atualizada com sucesso!";
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public ServiceResponse<DadosBancariosEnderecoDto> ObterDadosBancarios(Guid idPessoa)
    {
        var serviceResponse = new ServiceResponse<DadosBancariosEnderecoDto>();

        try
        {
            var resultado = _pessoaRepository.ObterDadosBancarios(idPessoa);

            serviceResponse.Dados = resultado;
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public ServiceResponse<EnderecoDto> ObterEndereco(string nomePessoa)
    {
        var serviceResponse = new ServiceResponse<EnderecoDto>();

        try
        {
            var resultado = _pessoaRepository.ObterEndereco(nomePessoa);

            serviceResponse.Dados = resultado;
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public ServiceResponse<List<PessoaDto>> ObterTodasPessoas(int pagina, int quantidade)
    {
        var serviceResponse = new ServiceResponse<List<PessoaDto>>();

        try
        {
            var resultado = _pessoaRepository.ObterTodasPessoas(pagina, quantidade);

            serviceResponse.Dados = _mapper.Map<List<PessoaDto>>(resultado);
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}
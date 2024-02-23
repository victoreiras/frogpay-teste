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

            var pessoa = new Pessoa(
                pessoaCriacaoDto.Nome, 
                pessoaCriacaoDto.Cpf, 
                pessoaCriacaoDto.DataNascimento);

            var endereco = new Endereco(
                pessoaCriacaoDto.Endereco.UfEstado, 
                pessoaCriacaoDto.Endereco.Cidade, 
                pessoaCriacaoDto.Endereco.Bairro,
                pessoaCriacaoDto.Endereco.Logradouro,
                pessoaCriacaoDto.Endereco.Numero,
                pessoaCriacaoDto.Endereco.Complemento);

            var loja = new Loja(
                pessoaCriacaoDto.Loja.NomeFantasia,
                pessoaCriacaoDto.Loja.RazaoSocial,
                pessoaCriacaoDto.Loja.Cnpj);

            var dadosBancarios = new DadosBancarios(
                pessoaCriacaoDto.DadosBancarios.CodigoBanco,
                pessoaCriacaoDto.DadosBancarios.Agencia,
                pessoaCriacaoDto.DadosBancarios.Conta,
                pessoaCriacaoDto.DadosBancarios.DigitoConta);
            
            pessoa.Endereco = endereco;
            pessoa.Loja = loja;
            pessoa.DadosBancarios = dadosBancarios;

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
                serviceResponse.Mensagem = "Pessoa não pode ser nula.";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            pessoa.Nome = pessoaEdicaoDto.Nome; 
            pessoa.Cpf = pessoaEdicaoDto.Cpf; 
            pessoa.DataNascimento = pessoaEdicaoDto.DataNascimento;

            pessoa.Endereco.UfEstado = pessoaEdicaoDto.Endereco.UfEstado;
            pessoa.Endereco.Cidade = pessoaEdicaoDto.Endereco.Cidade;
            pessoa.Endereco.Bairro = pessoaEdicaoDto.Endereco.Bairro;
            pessoa.Endereco.Logradouro = pessoaEdicaoDto.Endereco.Logradouro;
            pessoa.Endereco.Numero = pessoaEdicaoDto.Endereco.Numero;
            pessoa.Endereco.Complemento = pessoaEdicaoDto.Endereco.Complemento;

            pessoa.Loja.NomeFantasia = pessoaEdicaoDto.Loja.NomeFantasia;
            pessoa.Loja.RazaoSocial = pessoaEdicaoDto.Loja.RazaoSocial;
            pessoa.Loja.Cnpj = pessoaEdicaoDto.Loja.Cnpj;

            pessoa.DadosBancarios.CodigoBanco = pessoaEdicaoDto.DadosBancarios.CodigoBanco;
            pessoa.DadosBancarios.Agencia = pessoaEdicaoDto.DadosBancarios.Agencia;
            pessoa.DadosBancarios.Conta = pessoaEdicaoDto.DadosBancarios.Conta;
            pessoa.DadosBancarios.DigitoConta = pessoaEdicaoDto.DadosBancarios.DigitoConta;

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
}
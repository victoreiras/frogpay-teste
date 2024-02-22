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
                pessoaCriacaoDto.PessoaDto.Nome, 
                pessoaCriacaoDto.PessoaDto.Cpf, 
                pessoaCriacaoDto.PessoaDto.DataNascimento);

            var endereco = new Endereco(
                pessoaCriacaoDto.PessoaDto.Endereco.UfEstado, 
                pessoaCriacaoDto.PessoaDto.Endereco.Cidade, 
                pessoaCriacaoDto.PessoaDto.Endereco.Bairro,
                pessoaCriacaoDto.PessoaDto.Endereco.Logradouro,
                pessoaCriacaoDto.PessoaDto.Endereco.Numero,
                pessoaCriacaoDto.PessoaDto.Endereco.Complemento);

            var loja = new Loja(
                pessoaCriacaoDto.PessoaDto.Loja.NomeFantasia,
                pessoaCriacaoDto.PessoaDto.Loja.RazaoSocial,
                pessoaCriacaoDto.PessoaDto.Loja.Cnpj);

            var dadosBancarios = new DadosBancarios(
                pessoaCriacaoDto.PessoaDto.DadosBancarios.CodigoBanco,
                pessoaCriacaoDto.PessoaDto.DadosBancarios.Agencia,
                pessoaCriacaoDto.PessoaDto.DadosBancarios.Conta,
                pessoaCriacaoDto.PessoaDto.DadosBancarios.DigitoConta);
            
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

            pessoa.Nome = pessoaEdicaoDto.PessoaDto.Nome; 
            pessoa.Cpf = pessoaEdicaoDto.PessoaDto.Cpf; 
            pessoa.DataNascimento = pessoaEdicaoDto.PessoaDto.DataNascimento;

            pessoa.Endereco.UfEstado = pessoaEdicaoDto.PessoaDto.Endereco.UfEstado;
            pessoa.Endereco.Cidade = pessoaEdicaoDto.PessoaDto.Endereco.Cidade;
            pessoa.Endereco.Bairro = pessoaEdicaoDto.PessoaDto.Endereco.Bairro;
            pessoa.Endereco.Logradouro = pessoaEdicaoDto.PessoaDto.Endereco.Logradouro;
            pessoa.Endereco.Numero = pessoaEdicaoDto.PessoaDto.Endereco.Numero;
            pessoa.Endereco.Complemento = pessoaEdicaoDto.PessoaDto.Endereco.Complemento;

            pessoa.Loja.NomeFantasia = pessoaEdicaoDto.PessoaDto.Loja.NomeFantasia;
            pessoa.Loja.RazaoSocial = pessoaEdicaoDto.PessoaDto.Loja.RazaoSocial;
            pessoa.Loja.Cnpj = pessoaEdicaoDto.PessoaDto.Loja.Cnpj;

            pessoa.DadosBancarios.CodigoBanco = pessoaEdicaoDto.PessoaDto.DadosBancarios.CodigoBanco;
            pessoa.DadosBancarios.Agencia = pessoaEdicaoDto.PessoaDto.DadosBancarios.Agencia;
            pessoa.DadosBancarios.Conta = pessoaEdicaoDto.PessoaDto.DadosBancarios.Conta;
            pessoa.DadosBancarios.DigitoConta = pessoaEdicaoDto.PessoaDto.DadosBancarios.DigitoConta;

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
}
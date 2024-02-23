using Microsoft.AspNetCore.Mvc;
using src.FrogPay.Application.DTOs;
using src.FrogPay.Application.Interfaces;

namespace src.FrogPay.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{

    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost("cadastrarPessoa")]
    public IActionResult CadastrarPessoa(PessoaCriacaoDto pessoaDto)
    {
        var pessoaCadastrada = _pessoaService.CadastrarPessoa(pessoaDto);
        return Ok(pessoaCadastrada);
    }

    [HttpPut("editarPessoa")]
    public IActionResult EditarPessoa(PessoaEdicaoDto pessoaDto)
    {
        var pessoaEditada = _pessoaService.EditarPessoa(pessoaDto);
        return Ok(pessoaEditada);
    }

    [HttpGet("obterDadosBancarios")]
    public IActionResult ObterDadosBancarios(Guid idPessoa)
    {
        var dadosBancarios = _pessoaService.ObterDadosBancarios(idPessoa);
        return Ok(dadosBancarios);
    }

    [HttpGet("obterEndereco")]
    public IActionResult ObterEndereco(string nomePessoa)
    {
        var endereco = _pessoaService.ObterEndereco(nomePessoa);
        return Ok(endereco);
    }
}

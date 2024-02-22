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
    public IActionResult CadastrarPessoa(PessoaDto pessoaDto)
    {
        var pessoaCadastrada = _pessoaService.CadastrarPessoa(pessoaDto);
        return Ok(pessoaCadastrada);
    }

    [HttpGet("obterDadosBancarios")]
    public IActionResult ObterDadosBancarios(int idPessoa)
    {
        return Ok();
    }

    [HttpGet("obterEndereco")]
    public IActionResult ObterEndereco(string nome)
    {
        return Ok();
    }
}

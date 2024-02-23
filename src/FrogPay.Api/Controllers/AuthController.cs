using Microsoft.AspNetCore.Mvc;
using src.FrogPay.Application.DTOs;
using src.FrogPay.Application.Interfaces;

namespace src.FrogPay.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("registrar")]
    public ActionResult Registrar(UsuarioDto usuarioDto)
    {
        var usuarioRegistrado = _authService.Registrar(usuarioDto);
        return Ok(usuarioRegistrado);
    }

    [HttpPost("login")]
    public ActionResult Login(LoginDto loginDto)
    {
        var usuarioLogado = _authService.Login(loginDto);
        return Ok(usuarioLogado);
    }
}
using src.FrogPay.Application.DTOs;
using src.FrogPay.Application.Interfaces;
using src.FrogPay.Domain.Entities;
using src.FrogPay.Domain.Interfaces;

namespace src.FrogPay.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ISenhaService _senhaService;

    public AuthService(IUsuarioRepository usuarioRepository, ISenhaService senhaService)
    {
        _usuarioRepository = usuarioRepository;
        _senhaService = senhaService;
    }

    public ServiceResponse<string> Login(LoginDto loginDto)
    {
        var serviceResponse = new ServiceResponse<string>();

        try
        {
            var usuario = _usuarioRepository.ObterUsuario(loginDto.Usuario);

            if (usuario is null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Credenciais inválida";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            if (!_senhaService.VerificaSenhaHashValida(loginDto.Senha, usuario.SenhaHash, usuario.SenhaSalt))
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Credenciais inválida";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var token = _senhaService.GerarToken(usuario);

            serviceResponse.Dados = token;
            serviceResponse.Mensagem = "Usuário logado com sucesso";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public ServiceResponse<UsuarioDto> Registrar(UsuarioDto usuarioDto)
    {
        var serviceResponse = new ServiceResponse<UsuarioDto>();

        try
        {
            if (UsuarioJaExiste(usuarioDto))
            {
                serviceResponse.Mensagem = "Email já cadastrado";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            _senhaService.CriarSenhaHash(usuarioDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

            var usuario = new Usuario(usuarioDto.Usuario, senhaHash, senhaSalt);

            _usuarioRepository.Registrar(usuario);

            serviceResponse.Mensagem = "Usuário cadastrado com sucesso!";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;

    }

    private bool UsuarioJaExiste(UsuarioDto usuarioDto)
    {
        var usuarioBanco = _usuarioRepository.ObterUsuario(usuarioDto.Usuario);

        if (usuarioBanco is not null)
            return true;

        return false;
    }
}
using src.FrogPay.Application.DTOs;

namespace src.FrogPay.Application.Interfaces;

public interface IAuthService
{
    ServiceResponse<UsuarioDto> Registrar(UsuarioDto usuarioDto);
    ServiceResponse<string> Login(LoginDto loginDto); 
}
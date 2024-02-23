using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using src.FrogPay.Domain.Entities;
using src.FrogPay.Domain.Interfaces;

namespace src.FrogPay.Application.Services;

public class SenhaService : ISenhaService
{
    private readonly IConfiguration _config;

    public SenhaService(IConfiguration config)
    {
        _config = config;
    }

    public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }
    }

    public string GerarToken(Usuario usuario)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim("Usuario", usuario.UserName)
        };

        var secretKey = _config.GetSection("AppSettings:Token").Value;
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: credencial
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public bool VerificaSenhaHashValida(string senha, byte[] senhaHash, byte[] senhaSalt)
    {
        using (var hmac = new HMACSHA512(senhaSalt))
        {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            return computeHash.SequenceEqual(senhaHash);
        }
    }

}

namespace src.FrogPay.Domain.Entities;

public class Usuario
{
    public Usuario(string userName, byte[] senhaHash, byte[] senhaSalt)
    {
        UserName = userName;
        SenhaHash = senhaHash;
        SenhaSalt = senhaSalt;
    }

    public int Id { get; set; }
    public string UserName { get; set; }
    public byte[] SenhaHash { get; set; }
    public byte[] SenhaSalt { get; set; }
    public DateTime TokenDataCriacao { get; set; } = DateTime.Now;  
}

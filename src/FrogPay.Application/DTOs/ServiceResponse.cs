namespace src.FrogPay.Application.DTOs;
public record ServiceResponse<T>
{
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public bool Sucesso { get; set; } = true;
}
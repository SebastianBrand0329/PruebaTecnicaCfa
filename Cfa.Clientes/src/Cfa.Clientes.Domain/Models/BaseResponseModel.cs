namespace Cfa.Clientes.Domain.Models;

public class BaseResponseModel
{
    public int StatusCode { get; set; }
    public bool Sucess { get; set; }
    public string? Message { get; set; }
    public dynamic Data { get; set; }
}
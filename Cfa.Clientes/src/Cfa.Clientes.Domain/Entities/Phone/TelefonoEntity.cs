using Cfa.Clientes.Domain.Entities.Client;

namespace Cfa.Clientes.Domain.Entities.Phone;

public class TelefonoEntity
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public int ClienteId { get; set; }
    public ClienteEntity Cliente { get; set; }
}
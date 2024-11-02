using Cfa.Clientes.Domain.Entities.Client;

namespace Cfa.Clientes.Domain.Entities.Address;

public class DireccionEntity
{
    public int Id { get; set; }
    public string Detalle { get; set; }
    public int ClienteId { get; set; }
    public ClienteEntity Cliente { get; set; }
}
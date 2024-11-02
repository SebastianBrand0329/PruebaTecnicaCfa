using Cfa.Clientes.Domain.Entities.Address;
using Cfa.Clientes.Domain.Entities.Phone;

namespace Cfa.Clientes.Domain.Entities.Client;

public class ClienteEntity
{
    public int Id { get; set; }
    public string TipoDocumento { get; set; }
    public int NumeroDocumento { get; set; }
    public string Nombres { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Email { get; set; }
    public ICollection<DireccionEntity> Direcciones { get; set; }
    public ICollection<TelefonoEntity> Telefonos { get; set; }
}
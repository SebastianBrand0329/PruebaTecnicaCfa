using Cfa.Clientes.Domain.Entities.Address;
using Cfa.Clientes.Domain.Entities.Client;
using Cfa.Clientes.Domain.Entities.Phone;
using Microsoft.EntityFrameworkCore;

namespace Cfa.Clientes.Application;

public interface IDataBaseService
{
    DbSet<ClienteEntity> Clientes { get; set; }
    DbSet<DireccionEntity> Direcciones { get; set; }
    DbSet<TelefonoEntity> Telefonos { get; set; }

}
using Cfa.Clientes.Application;
using Cfa.Clientes.Domain.Entities.Address;
using Cfa.Clientes.Domain.Entities.Client;
using Cfa.Clientes.Domain.Entities.Phone;
using Cfa.Clientes.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Cfa.Clientes.Persistence.DataBase;

public class DataBaseService : DbContext, IDataBaseService
{
    public DataBaseService(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<ClienteEntity> Clientes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DbSet<DireccionEntity> Direcciones { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DbSet<TelefonoEntity> Telefonos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        EntityConfiguation(modelBuilder);
    }

    private void EntityConfiguation(ModelBuilder modelBuilder)
    {
        new ClienteConfiguration(modelBuilder.Entity<ClienteEntity>());
        new DireccionConfiguration(modelBuilder.Entity<DireccionEntity>());
        new TelefonoConfiguration(modelBuilder.Entity<TelefonoEntity>());
    }

}
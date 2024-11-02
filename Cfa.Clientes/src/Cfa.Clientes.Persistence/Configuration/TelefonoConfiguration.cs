using Cfa.Clientes.Domain.Entities.Phone;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cfa.Clientes.Persistence.Configuration
{
    public class TelefonoConfiguration
    {
        public TelefonoConfiguration(EntityTypeBuilder<TelefonoEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

     
            entityBuilder.Property(x => x.Numero)
                .IsRequired() 
                .HasMaxLength(15) 
                .IsUnicode(false); 

            // Configuración de la relación con ClienteEntity
            entityBuilder.HasOne(x => x.Cliente)
                .WithMany(c => c.Telefonos) 
                .HasForeignKey(x => x.ClienteId) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
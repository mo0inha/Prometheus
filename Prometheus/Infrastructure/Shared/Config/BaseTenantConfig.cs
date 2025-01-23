using Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Shared.Config
{
    public class BaseTenantConfig<TEntity> : BaseConfig<TEntity> where TEntity : TenantBaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.TenantId)
                .HasColumnName("ID_TENANT")
                .IsRequired();
        }
    }
}

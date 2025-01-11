using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

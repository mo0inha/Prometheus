using Domain.Entities;
using Infrastructure.Shared.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class TestEntityConfig : BaseTenantConfig<TestEntity>
    {
        public override void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_TEST_ENTITY");

            builder
                .Property(x => x.String)
                .HasColumnName("ST_STRING")
                .IsRequired();

            builder
                .Property(x => x.Int)
                .HasColumnName("NR_INT")
                .IsRequired();

            builder
                .Property(x => x.Bool)
                .HasColumnName("ST_BOOL")
                .IsRequired();
        }
    }
}

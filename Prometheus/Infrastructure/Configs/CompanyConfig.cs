using Domain.Entities;
using Infrastructure.Shared.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class CompanyConfig : BaseTenantConfig<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_COMPANY");

            builder
                .Property(x => x.Name)
                .HasColumnName("NM_NAME")
                .IsRequired();
        }
    }
}

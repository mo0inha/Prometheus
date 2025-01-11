using Domain.Entities;
using Infrastructure.Shared.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

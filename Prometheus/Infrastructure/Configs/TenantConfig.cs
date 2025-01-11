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
    public class TenantConfig : BaseConfig<Tenant>
    {
        public override void Configure(EntityTypeBuilder<Tenant> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_TENANT");

            builder
                .Property(x => x.Name)
                .HasColumnName("NM_NAME")
                .IsRequired();
        }
    }
}
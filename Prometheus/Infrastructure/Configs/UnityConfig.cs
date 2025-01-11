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
    public class UnityConfig : BaseTenantConfig<Unity>
    {
        public override void Configure(EntityTypeBuilder<Unity> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_UNITY");

            builder
                .Property(x => x.Name)
                .HasColumnName("NM_NAME")
                .IsRequired();

            builder
                .Property(x => x.CompanyId)
                .HasColumnName("ID_COMPANY")
                .IsRequired();
        }
    }
}

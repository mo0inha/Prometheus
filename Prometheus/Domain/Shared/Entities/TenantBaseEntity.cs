using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Entities
{
    public abstract class TenantBaseEntity : BaseEntity
    {
        protected TenantBaseEntity() { }
        public Guid TenantId { get; private set; } = Guid.NewGuid();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Request
{
    public class BaseTenantRequest<TResponse> : BaseRequest<TResponse>
    {
        private Guid TenantId;

        public void SetTenantId(Guid tenantId)
        {
            TenantId = tenantId;
        }

        public void SetIdTenantId(Guid id, Guid tenantId)
        {
            TenantId = tenantId;
            SetId(id);
        }

        public Guid GetTenantId()
        {
            return TenantId;
        }
    }
}

using Domain.Shared.Entities;

namespace Domain.Entities
{
    public class Unity : TenantBaseEntity
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}

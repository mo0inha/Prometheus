using Domain.Shared.Entities;

namespace Domain.Entities
{
    public class TestEntity : TenantBaseEntity
    {
        public string String { get; set; }
        public int Int { get; set; }
        public bool Bool { get; set; }
    }
}
namespace Domain.Shared.Entities
{
    public abstract class TenantBaseEntity : BaseEntity
    {
        protected TenantBaseEntity() { }
        public Guid TenantId { get; private set; } = Guid.NewGuid();
    }
}
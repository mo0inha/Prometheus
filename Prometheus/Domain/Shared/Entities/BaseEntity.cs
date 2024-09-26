using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public void InitializeAdd(bool? isActive = true)
        {
            IsActive = (bool)isActive;
            IsDeleted = false;
        }

        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
            UpdateTimestamp();
        }
        public void SetIsDelete()
        {
            IsDeleted = true;
            IsActive = false;
            UpdateTimestamp();
        }
    }
}
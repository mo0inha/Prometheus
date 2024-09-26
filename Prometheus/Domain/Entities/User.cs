using Domain.Enum;
using Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : TenantEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public ETypeUser TypeUser { get; set; }
        public Unity Unity { get; set; }
        public Guid UnityId { get; set; }
    }
}

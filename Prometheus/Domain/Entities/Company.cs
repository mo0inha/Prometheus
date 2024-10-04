using Domain.Enum;
using Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company : TenantBaseEntity
    {
        #region Son
        public ICollection<Unity> Unities { get; set; } = new List<Unity>();
        #endregion

        public string Name { get; set; }
        public ETypeCompany TypeCompany { get; set; }

        public void AddUnity(Unity unity)
        {
            unity.InitializeAdd();
            Unities.Add(unity);
        }

        public void RemoveUnity(Unity unity)
        {
            Unities.Remove(unity);
        }
    }
}

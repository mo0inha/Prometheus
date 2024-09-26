using Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tenant : BaseEntity
    {
        #region Son
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        #endregion

        public string Name { get; set; }

        public void AddCompany(Company company)
        {
            company.InitializeAdd();
            Companies.Add(company);
        }
    }
}

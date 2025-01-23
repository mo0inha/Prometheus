using Domain.Shared.Entities;
using Domain.Shared.Interface;

namespace Domain.Entities
{
    public class Tenant : BaseEntity, IAggregateRoot
    {
        #region Son
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        #endregion

        public string Name { get; set; }

        public Tenant(string name)
        {
            Name = name;
        }

        public void AddCompany(Company company)
        {
            company.InitializeAdd();
            Companies.Add(company);
        }

        public void RemoveCompany(Company company)
        {
            Companies.Remove(company);
        }
    }
}

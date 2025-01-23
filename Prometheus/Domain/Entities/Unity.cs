using Domain.Enum;
using Domain.Shared.Entities;

namespace Domain.Entities
{
    public class Unity : TenantBaseEntity
    {
        #region Son
        public ICollection<User> Users { get; set; } = new List<User>();
        #endregion

        public string Name { get; set; }
        public ETypeUnity TypeUnity { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public Address Address { get; set; }
        public Guid AddressId { get; set; }

        public void AddUser(User user)
        {
            user.InitializeAdd();
            Users.Add(user);
        }
    }
}

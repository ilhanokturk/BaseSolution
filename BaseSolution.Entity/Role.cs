using BaseSolution.Entity.Base;
using System.Collections.Generic;

namespace BaseSolution.Entity
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}

using BaseSolution.Entity.Base;
using System;

namespace BaseSolution.Entity
{
    public class UserRole:BaseDateEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}

using BaseSolution.Entity.Base;
using System;
using System.Collections.Generic;

namespace BaseSolution.Entity
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }


        public virtual IList<UserRole> UserRoles { get; set; }
        public virtual IList<ArticleComment> ArticleComments { get; set; }
    }
}

using BaseSolution.Entity.Base;
using System;
using System.Collections.Generic;

namespace BaseSolution.Entity
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Guid? ParentId { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}

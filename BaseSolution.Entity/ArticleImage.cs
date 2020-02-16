using BaseSolution.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Entity
{
    public class ArticleImage:BaseEntity
    {
        public string Url { get; set; }
        public string Slug { get; set; }
        public Guid ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}

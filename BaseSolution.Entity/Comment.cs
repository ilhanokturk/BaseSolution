using BaseSolution.Entity.Base;
using System.Collections.Generic;

namespace BaseSolution.Entity
{
    public class Comment:BaseEntity
    {
        public string Message { get; set; }

        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    }
}

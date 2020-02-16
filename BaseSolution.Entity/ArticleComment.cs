using BaseSolution.Entity.Base;
using System;

namespace BaseSolution.Entity
{
    public class ArticleComment : BaseDateEntity
    {
        public Guid ArticleId { get; set; }
        public Guid CommentId { get; set; }
        public Guid? UserId { get; set; }


        public virtual Comment Comment { get; set; }
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}

using BaseSolution.Entity.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSolution.Entity
{
    public class Article:BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string ViewCount { get; set; }
        public string Author { get; set; }
        public bool? IsSlide { get; set; }
        public bool? IsPublish { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid CategoryId { get; set; }
        public byte[] RowVersion { get; set; }

        //[ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<ArticleImage> ArticleImages  { get; set; }
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    }
}

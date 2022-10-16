using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Models
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        public int ParentId { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}

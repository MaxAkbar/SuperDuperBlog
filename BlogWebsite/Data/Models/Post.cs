using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Models
{
    public partial class Post
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Summary { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? PublishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}

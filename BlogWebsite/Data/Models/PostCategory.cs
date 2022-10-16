using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Models
{
    public partial class PostCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
    }
}

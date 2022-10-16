using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Models
{
    public partial class Tag
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Active { get; set; }
    }
}

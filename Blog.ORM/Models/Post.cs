using System;

namespace Blog.ORM.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public DateTime CreateDate { get; set; }
        public TimeSpan ReadingTime { get; set; } = new TimeSpan();
        public Guid Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }

    }
}

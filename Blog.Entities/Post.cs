using System;

namespace Blog.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public DateTime CreateDate { get; set; }
        public TimeSpan ReadingTime { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }
    }
}

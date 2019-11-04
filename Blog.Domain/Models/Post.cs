using System;

namespace Blog.Domain.Models
{
    public class Post
    {
        public Post()
        {

        }

        public DateTime CreateDate { get; set; }
        public TimeSpan ReadingTime { get; set; } = new TimeSpan();
        public string Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }

    }
}

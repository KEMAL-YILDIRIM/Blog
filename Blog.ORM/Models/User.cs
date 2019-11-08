using System;
using System.Collections.Generic;

using Blog.ORM.Context;

namespace Blog.ORM.Models
{
    public class User : IPersistance
    {
        public User()
        {

        }

        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}

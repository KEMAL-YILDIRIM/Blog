using System;

namespace Blog.Domain.Entities
{
    public class User
    {
        public User()
        {

        }

        public string FullName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}

using Blog.Entities;
using Blog.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories.Derived
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly DbContext _context;
        public UserRepository(DbContext context)
            : base(context)
        {
            _context = context;
        }

    }
}

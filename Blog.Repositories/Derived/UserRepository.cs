using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Blog.Entities;
using Blog.Logic.Repositories;
using Blog.ORM.Context;
using Blog.Repositories.Base;

namespace Blog.Repositories.Derived
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public UserRepository(BlogContext context)
            : base(context)
        {
            _context = context;
        }

        public UserRepository(BlogContext context,
            IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var userORM = await Task.FromResult(
                _context.Users.SingleOrDefault(
                    u => email.Equals(u.Email, System.StringComparison.CurrentCultureIgnoreCase)
                ));

            var userDomain = _mapper.Map<ORM.Models.User, User>(userORM);

            return userDomain;
        }

    }
}

using System.Linq;
using System.Threading.Tasks;

using Blog.Logic.Repositories;
using Blog.ORM.Context;
using Blog.Repositories.Base;

using DomainUser = Blog.Entities.User;
using PersistanceUser = Blog.ORM.Models.User;

namespace Blog.Repositories.Derived
{
    public class UserRepository : BaseRepository<DomainUser, PersistanceUser>, IUserRepository
    {
        private readonly BlogContext _context;
        private readonly IMap<DomainUser, PersistanceUser> _map;

        public UserRepository(BlogContext context,
            IMap<DomainUser, PersistanceUser> map)
           : base(context, map)
        {
            _context = context;
            _map = map;

        }

        public async Task<DomainUser> GetByEmailAsync(string email)
        {
            var userORM = await Task.FromResult(
                _context.Users.SingleOrDefault(
                    u => email.Equals(u.Email, System.StringComparison.CurrentCultureIgnoreCase)
                ));


            var userDomain = _map.PersistanceToDomain(userORM);
            return userDomain;
        }
    }
}

using System.Threading.Tasks;

using Blog.Entities;

namespace Blog.Logic.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
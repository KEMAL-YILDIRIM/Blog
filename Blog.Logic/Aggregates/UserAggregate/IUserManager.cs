using System.Threading.Tasks;

using Blog.Entities;

namespace Blog.Logic.Aggregates.UserAggregate
{
    public interface IUserManager
    {
        Task<(string error, bool isValid)> RegisterAsync(User user);
    }
}
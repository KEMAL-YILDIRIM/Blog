using System.Threading.Tasks;
using Blog.Entities;

namespace Blog.Logic.Managers
{
    public interface IUserManager
    {
        Task<(string error, bool isValid)> RegisterAsync(User user);
    }
}
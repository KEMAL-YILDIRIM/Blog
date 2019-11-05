using Blog.Entities;

namespace Blog.Logic.Managers
{
    public interface IUserManager
    {
        (string error, bool isValid) Register(User user);
    }
}
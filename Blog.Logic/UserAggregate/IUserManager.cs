
using Blog.Domain.AuditableEntities;

using System.Threading.Tasks;

namespace Blog.Logic.UserAggregate
{
	public interface IUserManager
	{
		Task<(string error, bool isValid)> RegisterAsync(User user);
	}
}
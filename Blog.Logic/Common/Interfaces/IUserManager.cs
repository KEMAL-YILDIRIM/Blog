using System.Threading.Tasks;

using Blog.Logic.Common.Models;

namespace Blog.Logic.Common.Interfaces
{
	public interface IUserManager
	{
		Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

		Task<Result> DeleteUserAsync(string userId);
	}
}

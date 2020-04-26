using Blog.Domain.AuditableEntities;

using System.Threading.Tasks;

namespace Blog.Logic.Repositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> GetByEmailAsync(string email);
	}
}
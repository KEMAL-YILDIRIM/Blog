using Blog.Logic.Common.Models;

using System.Threading.Tasks;

namespace Blog.Logic.Common.Interfaces
{
	public interface INotificationService
	{
		Task SendAsync(MessageDto message);
	}
}
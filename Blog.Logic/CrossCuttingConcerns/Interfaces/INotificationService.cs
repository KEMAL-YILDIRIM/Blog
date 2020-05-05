using System.Threading.Tasks;

using Blog.Logic.CrossCuttingConcerns.Models;

namespace Blog.Logic.CrossCuttingConcerns.Interfaces
{
	public interface INotificationService
	{
		Task SendAsync(MessageDto message);
	}
}
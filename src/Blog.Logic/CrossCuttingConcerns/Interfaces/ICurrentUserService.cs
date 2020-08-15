namespace Blog.Logic.CrossCuttingConcerns.Interfaces
{
	public interface ICurrentUserService
	{
		string UserId { get; }

		bool IsAuthenticated { get; }
	}
}

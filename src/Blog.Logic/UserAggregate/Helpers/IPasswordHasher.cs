namespace Blog.Logic.UserAggregate.Helpers
{
	public interface IPasswordHasher
	{
		string Create(string password);
		bool Verify(string password, string storedPassword);
	}
}
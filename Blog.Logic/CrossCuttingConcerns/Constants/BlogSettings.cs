namespace Blog.Logic.CrossCuttingConcerns.Constants
{
	public static class BlogSettings
	{
		public static string ConnectionStringName { get => "BlogContext"; }
		public static string ApplicationName { get => "Blog"; }
		public static byte[] Salt { get => new byte[] { 81, 2, 4, 1, 2, 3, 1, 4, 6, 4, 7, 8, 3, 42, 2, 231, 12, 1, 4, }; }
	}
}

namespace Blog.Logic.CrossCuttingConcerns.Constants
{
	public static class BlogSettings
	{
		public static string Secret => "3Ei236oikmr98d8FdEAA09*dsAA";
		public static string ConnectionStringName => "BlogContext";
		public static string ApplicationName => "Blog";
		public static byte[] Salt => new byte[] { 81, 2, 4, 1, 2, 3, 1, 4, 6, 4, 7, 8, 3, 42, 2, 231, 12, 1, 4, };
		public static int RefreshTokenLifeAsDays => 60;
	}
}

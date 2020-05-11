using Blog.Logic.CrossCuttingConcerns.Constants;

using System;

namespace Blog.Logic.UserAggregate.Helpers
{
	public class PasswordHasher : IPasswordHasher
	{
		public virtual string Create(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentNullException(nameof(password));

			using (var hmac = new System.Security.Cryptography.HMACSHA512(BlogSettings.Salt))
			{
				var hash = hmac
					.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
					.ToString();

				return hash;
			}
		}

		public virtual bool Verify(string password, string storedPassword)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentNullException(nameof(password));

			using (var hmac = new System.Security.Cryptography.HMACSHA512(BlogSettings.Salt))
			{
				var computedHash = hmac
					.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
					.ToString();

				return storedPassword == computedHash;
			}
		}
	}
}

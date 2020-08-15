using Blog.Domain.ValueObjects;
using Blog.Logic.CrossCuttingConcerns.Constants;

using System;
using System.Security.Cryptography;

namespace Blog.Logic.UserAggregate.Helpers
{
	public class TokenProvider : ITokenProvider
	{
		public RefreshToken GenerateToken(string userIp)
		{
			using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				var randomBytes = new byte[64];
				rngCryptoServiceProvider.GetBytes(randomBytes);
				var token = Convert.ToBase64String(randomBytes);

				return new RefreshToken
				{
					Token = token,
					CreatedAt = DateTime.Now,
					OwnerIp = userIp,
					RevokedAt = null,
					ExpiresAt = DateTime.Now.AddDays(BlogSettings.RefreshTokenLifeAsDays)
				};
			}
		}
	}
}

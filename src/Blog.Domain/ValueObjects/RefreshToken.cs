using System;
using System.Collections.Generic;

using Blog.Domain.Common;

namespace Blog.Domain.ValueObjects
{
	public class RefreshToken : ValueObject
	{
		public string Token { get; set; }
		public string OwnerIp { get; set; }
		public DateTime ExpiresAt { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? RevokedAt { get; set; }
		public string OwnerId { get; set; }


		public bool IsActive => RevokedAt == null && !IsExpired;
		public bool IsExpired => DateTime.UtcNow >= ExpiresAt;


		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Token;
			yield return ExpiresAt;
			yield return CreatedAt;
			yield return OwnerIp;
			yield return OwnerId;
			yield return RevokedAt;
			yield return IsActive;
			yield return IsExpired;
		}
	}
}

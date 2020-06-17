using Blog.Domain.CrossCuttingConcerns;

using System;
using System.Collections.Generic;

namespace Blog.Domain.ValueObjects
{
	public class RefreshToken : ValueObject
	{
		public string Token { get; set; }
		public string OwnerIp { get; set; }
		public DateTime Expires { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Revoked { get; set; }


		public bool IsActive => Revoked == null && !IsExpired;
		public bool IsExpired => DateTime.UtcNow >= Expires;


		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Token;
			yield return Expires;
			yield return Created;
			yield return OwnerIp;
			yield return Revoked;
			yield return IsActive;
			yield return IsExpired;
		}
	}
}

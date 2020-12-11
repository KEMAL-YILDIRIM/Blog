
using System.Collections.Generic;

using Blog.Domain.Common;
using Blog.Domain.PropertyEntities;

namespace Blog.Domain.ValueObjects
{
	public class Phone : ValueObject
	{
		public string Number { get; set; }
		public string UserId { get; set; }
		public Type Type { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Number;
			yield return UserId;
			yield return Type.Name;
		}
	}
}

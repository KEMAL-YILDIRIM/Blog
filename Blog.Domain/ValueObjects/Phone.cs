
using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.PropertyEntities;

using System.Collections.Generic;

namespace Blog.Domain.ValueObjects
{
	public class Phone : ValueObject
	{
		public string Number { get; set; }
		public string UserId { get; set; }
		public Type Type { get; set; }

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Number;
			yield return UserId;
			yield return Type.Name;
		}
	}
}

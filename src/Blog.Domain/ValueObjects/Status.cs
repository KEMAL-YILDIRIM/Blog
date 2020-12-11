
using System.Collections.Generic;

using Blog.Domain.Common;
using Blog.Domain.PropertyEntities;

namespace Blog.Domain.ValueObjects
{
	public class Status : ValueObject
	{
		public string Name { get; set; }
		public Type Type { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Name;
			yield return Type.Name;
		}
	}
}

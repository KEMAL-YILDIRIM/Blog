
using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.PropertyEntities;
using System.Collections.Generic;

namespace Blog.Domain.ValueObjects
{
	public class Status : ValueObject
	{
		public string Name { get; set; }
		public Type Type { get; set; }

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Name;
			yield return Type.Name;
		}
	}
}

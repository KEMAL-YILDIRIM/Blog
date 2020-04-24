
using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.PropertyEntities;

using System.Collections.Generic;

namespace Blog.Domain.ValueObjects
{
	public class Phone : ValueObject
	{
		public string Number { get; set; }
		public Type Type { get; set; }

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Number;
			yield return Type.Name;
		}
	}
}

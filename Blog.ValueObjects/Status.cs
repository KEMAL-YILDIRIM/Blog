
using System.Collections.Generic;

namespace Blog.ValueObjects
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

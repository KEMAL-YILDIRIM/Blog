
using System.Collections.Generic;

namespace Blog.ValueObjects
{
	public class Priority : ValueObject
	{
		public string Name { get; set; }

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Name;
		}
	}
}

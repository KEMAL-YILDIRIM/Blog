
using Blog.Domain.Common;
using Blog.Domain.PropertyEntities;

using System.Collections.Generic;

namespace Blog.Domain.ValueObjects
{
	public class Address : ValueObject
	{
		public string Line { get; set; }
		public string PostCode { get; set; }


		public City City { get; set; }
		public Country Country { get; set; }
		public Type Type { get; set; }

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Line;
			yield return City.Name;
			yield return Type.Name;
			yield return Country.Name;
			yield return PostCode;
		}
	}
}

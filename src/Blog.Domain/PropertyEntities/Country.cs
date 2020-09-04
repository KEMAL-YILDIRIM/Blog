using Blog.Domain.Common;

namespace Blog.Domain.PropertyEntities
{
	public class Country : PropertyEntity
	{
		public Country(int id, string name) : base(id, name)
		{
		}
		public Country(string name) : base(name)
		{
		}

		public Country()
		{
		}
	}
}
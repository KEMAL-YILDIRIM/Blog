using Blog.Entities.Seed;

namespace Blog.Entities.PropertyEntities
{
	public class DomainType : PropertyEntity
	{
		public DomainType(int id, string name) : base(id, name)
		{
		}

		public DomainType(string name) : base(name)
		{
		}

		public DomainType()
		{
		}
	}
}
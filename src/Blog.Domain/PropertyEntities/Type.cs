using Blog.Domain.Common;

namespace Blog.Domain.PropertyEntities
{
	public class Type : PropertyEntity
	{
		public Type(int id, string name) : base(id, name)
		{
		}

		public Type(string name) : base(name)
		{
		}

		public Type()
		{
		}
	}
}
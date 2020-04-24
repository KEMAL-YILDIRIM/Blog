using Blog.Domain.CrossCuttingConcerns;

namespace Blog.Domain.PropertyEntities
{
	public class City : PropertyEntity
	{
		public City(int id, string name) : base(id, name)
		{
		}

		public City(string name) : base(name)
		{
		}

		public City()
		{
		}

		public Country Country { get; set; }
	}
}
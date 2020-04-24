namespace Blog.Domain.CrossCuttingConcerns
{
	public abstract class PropertyEntity
	{
		public string Name { get; private set; }

		public int Id { get; private set; }

		protected PropertyEntity(int id, string name)
		{
			Id = id;
			Name = name;
		}

		protected PropertyEntity(string name)
		{
			Name = name;
		}

		public PropertyEntity()
		{

		}
	}
}

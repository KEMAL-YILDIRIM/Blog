using AutoMapper;

namespace Blog.Logic.CrossCuttingConcerns.Mappings
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
	}
}

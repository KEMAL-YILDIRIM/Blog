using AutoMapper;

namespace Blog.Logic.CrossCuttingConcerns.Mappings
{
	public interface IMapTo<T>
	{
		void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
	}
}

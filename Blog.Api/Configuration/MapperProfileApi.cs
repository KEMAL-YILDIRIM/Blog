using AutoMapper;

using Blog.Api.Dtos;
using Blog.Domain.AuditableEntities;

namespace Blog.Api.Configuration
{
	public class MapperProfileApi : Profile
	{
		public MapperProfileApi()
		{
			CreateMap<RegisterDto, User>()
				.IgnoreAllPropertiesWithAnInaccessibleSetter();
		}
	}
}

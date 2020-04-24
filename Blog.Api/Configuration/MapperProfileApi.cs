using AutoMapper;

using Blog.Api.Dtos;
using Blog.Domain.AuditableEntities;
using Blog.Logic.Configuration;

namespace Blog.Api.Configuration
{
	public class MapperProfileApi : Profile
	{
		public MapperProfileApi()
		{
			CreateMap<Register, User>()
				.IgnoreAllUnmapped();
		}
	}
}

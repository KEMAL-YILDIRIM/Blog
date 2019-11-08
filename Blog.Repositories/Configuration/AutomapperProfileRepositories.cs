using AutoMapper;

using Blog.Entities;
using Blog.Logic.Configuration;

namespace Blog.Repositories.Configuration
{
    public class AutomapperProfileRepositories : Profile
    {
        public AutomapperProfileRepositories()
        {
            CreateMap<User, Blog.ORM.Models.User>()
                .IgnoreAllUnmapped();
        }
    }
}

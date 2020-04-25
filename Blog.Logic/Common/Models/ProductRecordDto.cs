using AutoMapper;

using Blog.Domain.AuditableEntities;
using Blog.Logic.Common.Mappings;

namespace Blog.Logic.Common.Models
{
	public class EntryDto : IMapFrom<Entry>
	{
		public string EntryTitle { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Entry, EntryDto>()
				.ForMember(d => d.EntryTitle, opt => opt.MapFrom(s => s.Title));
		}
	}
}

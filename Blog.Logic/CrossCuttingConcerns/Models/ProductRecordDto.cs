using AutoMapper;

using Blog.Domain.AuditableEntities;
using Blog.Logic.CrossCuttingConcerns.Mappings;

namespace Blog.Logic.CrossCuttingConcerns.Models
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

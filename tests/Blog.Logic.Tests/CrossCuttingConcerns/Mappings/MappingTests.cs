using AutoMapper;

using Blog.Logic.CrossCuttingConcerns.Mappings;

using NUnit.Framework;

namespace Blog.Logic.Tests.CrossCuttingConcerns.Mappings
{
	[TestFixture]
	public class MappingTests
	{
		private readonly IConfigurationProvider _configuration;
		private readonly IMapper _mapper;

		public MappingTests()
		{
			_configuration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = _configuration.CreateMapper();
		}

		[Test]
		public void ShouldHaveValidConfiguration()
		{
			_configuration.AssertConfigurationIsValid();
		}

		[Test]
		public void ShouldMapCategoryToCategoryDto()
		{
			//var entity = new Category();

			//var result = _mapper.Map<CategoryDto>(entity);

			//result.ShouldNotBeNull();
			//result.ShouldBeOfType<CategoryDto>();
		}
	}
}

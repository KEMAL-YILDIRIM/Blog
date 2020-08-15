using AutoMapper;

using Blog.Domain.CrossCuttingConcerns;
using Blog.ORM.Context;

using System.Collections.Generic;

namespace Blog.Repositories.Base
{
	public class Map<TDomain, TPersistance> : IMap<TDomain, TPersistance> where TDomain : IEntity
		where TPersistance : IPersistance
	{
		private readonly IMapper _mapper;

		public Map(IMapper mapper)
		{
			_mapper = mapper;
		}

		public TDomain PersistanceToDomain(TPersistance persistance)
		{
			return _mapper.Map<TPersistance, TDomain>(persistance);
		}

		public TPersistance DomainToPersistance(TDomain domain)
		{
			return _mapper.Map<TDomain, TPersistance>(domain);
		}

		public IEnumerable<TDomain> PersistanceToDomain(IEnumerable<TPersistance> persistance)
		{
			return _mapper.Map<IEnumerable<TPersistance>, IEnumerable<TDomain>>(persistance);
		}

		public IEnumerable<TPersistance> DomainToPersistance(IEnumerable<TDomain> domain)
		{
			return _mapper.Map<IEnumerable<TDomain>, IEnumerable<TPersistance>>(domain);
		}
	}
}

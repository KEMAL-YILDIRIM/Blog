using Blog.Domain.CrossCuttingConcerns;
using Blog.ORM.Context;

using System.Collections.Generic;

namespace Blog.Repositories.Base
{
	public interface IMap<TDomain, TPersistance>
		where TDomain : IEntity
		where TPersistance : IPersistance
	{
		IEnumerable<TPersistance> DomainToPersistance(IEnumerable<TDomain> domain);
		TPersistance DomainToPersistance(TDomain domain);
		IEnumerable<TDomain> PersistanceToDomain(IEnumerable<TPersistance> persistance);
		TDomain PersistanceToDomain(TPersistance persistance);
	}
}
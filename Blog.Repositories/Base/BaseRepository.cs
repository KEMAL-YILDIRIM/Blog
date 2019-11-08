using System.Threading.Tasks;

using Blog.Entities;
using Blog.Logic.Repositories;
using Blog.ORM.Context;

using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories.Base
{
    public abstract class BaseRepository<TEntity, TPersistance>
        : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TPersistance : class, IPersistance
    {
        private readonly DbContext _context;
        private readonly IMap<TEntity, TPersistance> _map;

        public BaseRepository(DbContext context,
            IMap<TEntity, TPersistance> map)
        {
            _context = context;
            _map = map;
        }

        public virtual async Task<TEntity> Find(int Id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Id);
            return entity;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            var model = _map.DomainToPersistance(entity);
            _context.Set<TPersistance>().Add(model);
            await _context.SaveChangesAsync();
            entity = _map.PersistanceToDomain(model);
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            var model = _map.DomainToPersistance(entity);
            // In case AsNoTracking is used
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            entity = _map.PersistanceToDomain(model);
            return entity;
        }

        public virtual async Task<bool> Remove(TEntity entity)
        {
            var model = _map.DomainToPersistance(entity);
            _context.Set<TPersistance>().Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
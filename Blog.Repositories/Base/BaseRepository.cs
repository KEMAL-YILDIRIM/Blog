using System.Threading.Tasks;

using Blog.Logic.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Find(int Id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Id);
            return entity;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
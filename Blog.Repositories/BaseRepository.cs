using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Find(int Id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Id);
            return entity;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

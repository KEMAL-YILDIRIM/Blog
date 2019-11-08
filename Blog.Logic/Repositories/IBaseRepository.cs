using System.Threading.Tasks;

namespace Blog.Logic.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Find(int Id);
        Task<bool> Remove(TEntity entity);
        Task<TEntity> Update(TEntity entity);
    }
}
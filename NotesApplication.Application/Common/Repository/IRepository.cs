using NotesApplication.Domain;
using System.Linq.Expressions;

namespace NotesApplication.Application.Common.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        public TEntity Add(TEntity entity);
        public void Delete(TEntity entity);

        public Task<TEntity> GetAsync(int id);

        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task SaveChangesAsync();

        public Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}

using NotesApplication.Domain;

namespace NotesApplication.Application.Common.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        public TEntity Add(TEntity entity);
        public void Delete(TEntity entity);

        public Task<TEntity> GetAsync(int id);

        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task SaveChangesAsync();

        public Task<bool> ContainsAsync(Func<TEntity, bool> predicate);
    }
}

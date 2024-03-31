using NotesApplication.Application.Common.Repository;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tests.Common
{
    public class TestRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private List<TEntity> _storage;

        public TestRepository()
        {
            _storage = new List<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _storage.Add(entity);

            return entity;
        }

        public Task<bool> ContainsAsync(Func<TEntity, bool> predicate)
        {
            return Task.FromResult(_storage.Any(predicate));
        }

        public void Delete(TEntity entity)
        {
            _storage.Remove(entity);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(int id)
        {
            return Task.FromResult(_storage.Find(x => x.Id == id));
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}

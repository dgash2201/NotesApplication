using NotesApplication.Application.Common.Repository;
using NotesApplication.Domain;
using System.Linq.Expressions;

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

        public Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(_storage.Any(predicate.Compile()));
        }

        public void Delete(TEntity entity)
        {
            _storage.Remove(entity);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(_storage.FirstOrDefault(predicate.Compile()));
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}

using NotesApplication.Domain;
using NotesApplication.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NotesApplication.Application.Common.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly NotesDbContext _db;

        public Repository(NotesDbContext db)
        {
            _db = db;
        }

        public TEntity Add(TEntity entity)
        {
            _db.Add(entity);
            return entity;
        }

        public async Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().AnyAsync(predicate);
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> result = await _db.Set<TEntity>().ToListAsync();

            return result;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}

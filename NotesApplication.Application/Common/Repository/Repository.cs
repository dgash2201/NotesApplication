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

        public async Task<bool> ContainsAsync(Func<TEntity, bool> predicate)
        {
            return await _db.Set<TEntity>().AnyAsync(x => predicate(x));
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Domain;
using NotesApplication.Infrastructure;
using System.Linq.Expressions;

namespace NotesApplication.Application.Notes.Repository
{
    public class NoteRepository : Repository<Note>
    {
        private readonly NotesDbContext _db;

        public NoteRepository(NotesDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Note>> GetAllAsync()
        {
            IEnumerable<Note> result = await _db.Notes.Include(x => x.Tags).ToListAsync();

            return result;
        }

        public override async Task<Note> GetAsync(Expression<Func<Note, bool>> predicate)
        {
            return await _db.Notes.Include(x => x.Tags).FirstOrDefaultAsync(predicate);
        }
    }
}

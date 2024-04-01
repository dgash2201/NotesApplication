using Microsoft.EntityFrameworkCore;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Domain;
using NotesApplication.Infrastructure;
using System.Linq.Expressions;

namespace NotesApplication.Application.Reminders.Repository
{
    public class ReminderRepository : Repository<Reminder>
    {
        private readonly NotesDbContext _db;

        public ReminderRepository(NotesDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Reminder>> GetAllAsync()
        {
            IEnumerable<Reminder> result = await _db.Reminders.Include(x => x.Tags).ToListAsync();

            return result;
        }

        public override async Task<Reminder> GetAsync(Expression<Func<Reminder, bool>> predicate)
        {
            return await _db.Reminders.Include(x => x.Tags).FirstOrDefaultAsync(predicate);
        }
    }
}

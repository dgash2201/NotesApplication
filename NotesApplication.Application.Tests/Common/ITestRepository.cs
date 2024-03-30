using NotesApplication.Application.Common.Repository;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tests.Common
{
    public interface ITestRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
    }
}

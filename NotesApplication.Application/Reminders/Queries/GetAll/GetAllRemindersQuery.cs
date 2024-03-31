using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Queries.GetAll
{
    public class GetAllRemindersQuery : IRequest<Response<IEnumerable<Reminder>>>
    {
    }
}

using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Reminders.Queries.Get;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Reminders
{
    public class GetReminderQueryHandlerTests
    {
        private readonly GetReminderQueryHandler _handler;
        private readonly IRepository<Reminder> _repository;

        public GetReminderQueryHandlerTests()
        {
            _repository = new TestRepository<Reminder>();
            _handler = new GetReminderQueryHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var reminder = new Reminder()
            {
                Id = 1,
                Title = "reminder1"
            };

            _repository.Add(reminder);

            // Act
            var reminderResponse = await _handler.Handle(new GetReminderQuery { Id = reminder.Id }, CancellationToken.None);


            // Assert
            Assert.NotNull(reminderResponse);
            Assert.True(reminderResponse.IsSuccess);
            Assert.Equal(reminder.Title, reminderResponse.Value.Title);
        }
    }
}

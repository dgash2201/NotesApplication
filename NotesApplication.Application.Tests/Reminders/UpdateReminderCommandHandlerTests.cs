using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Reminders.Commands.Update;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Reminders
{
    public class UpdateReminderCommandHandlerTests
    {
        private readonly UpdateReminderCommandHandler _handler;
        private readonly IRepository<Reminder> _repository;

        public UpdateReminderCommandHandlerTests()
        {
            _repository = new TestRepository<Reminder>();
            _handler = new UpdateReminderCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var id = 1;
            var title = "Reminder1";
            var newTitle = "Reminder2";
            var toUpdate = new Reminder
            {
                Id = id,
                Title = title,
            };

            _repository.Add(toUpdate);

            // Act
            var reminderResponse = await _handler.Handle(new UpdateReminderCommand { Id = id, Title = newTitle }, CancellationToken.None);


            // Assert
            Assert.NotNull(reminderResponse);
            Assert.True(reminderResponse.IsSuccess);
            Assert.Equal(toUpdate.Title, newTitle);
        }
    }
}

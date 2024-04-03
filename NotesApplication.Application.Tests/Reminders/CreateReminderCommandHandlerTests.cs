using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Reminders.Commands.Create;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Reminders
{
    public class CreateReminderCommandHandlerTests
    {
        private readonly CreateReminderCommandHandler _handler;
        private readonly Application.Common.Repository.IRepository<Reminder> _repository;

        public CreateReminderCommandHandlerTests()
        {
            _repository = new TestRepository<Reminder>();
            _handler = new CreateReminderCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var title = "Reminder1";

            // Act
            var reminderResponse = await _handler.Handle(new CreateReminderCommand { Title = title }, CancellationToken.None);


            // Assert
            Assert.NotNull(reminderResponse);
            Assert.True(reminderResponse.IsSuccess);
            Assert.Equal(title, reminderResponse.Value.Title);
        }

        [Fact]
        public async Task NotCreateExistingReminder()
        {
            // Arrange
            var title = "Reminder1";
            _repository.Add(new Reminder { Title = title });
            await _repository.SaveChangesAsync();

            // Act
            var reminderResponse = await _handler.Handle(new CreateReminderCommand { Title = title }, CancellationToken.None);

            // Assert
            Assert.NotNull(reminderResponse);
            Assert.False(reminderResponse.IsSuccess);
        }
    }
}

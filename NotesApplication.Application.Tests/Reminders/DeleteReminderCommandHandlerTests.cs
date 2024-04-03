using NotesApplication.Application.Reminders.Commands.Delete;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Reminders
{
    public class DeleteReminderCommandHandlerTests
    {
        private readonly DeleteReminderCommandHandler _handler;
        private readonly Application.Common.Repository.IRepository<Reminder> _repository;

        public DeleteReminderCommandHandlerTests()
        {
            _repository = new TestRepository<Reminder>();
            _handler = new DeleteReminderCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var id = 1;
            var title = "Reminder1";
            var toDelete = new Reminder
            {
                Id = id,
                Title = title,
            };

            _repository.Add(toDelete);

            // Act
            var reminderResponse = await _handler.Handle(new DeleteReminderCommand { Id = id }, CancellationToken.None);


            // Assert
            Assert.NotNull(reminderResponse);
            Assert.True(reminderResponse.IsSuccess);
            Assert.False(await _repository.ContainsAsync(x => x.Id == id));
        }

        [Fact]
        public async Task FailsIfReminderNotExist()
        {
            // Arrange
            var id = 1;
            var title = "Reminder1";
            var toDelete = new Reminder
            {
                Id = id,
                Title = title,
            };

            // Act
            var reminderResponse = await _handler.Handle(new DeleteReminderCommand { Id = id }, CancellationToken.None);


            // Assert
            Assert.NotNull(reminderResponse);
            Assert.False(reminderResponse.IsSuccess);
        }
    }
}

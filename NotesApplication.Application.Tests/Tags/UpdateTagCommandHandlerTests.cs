using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Tags.Commands.Update;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Tags
{
    public class UpdateTagCommandHandlerTests
    {
        private readonly UpdateTagCommandHandler _handler;
        private readonly IRepository<Tag> _repository;

        public UpdateTagCommandHandlerTests()
        {
            _repository = new TestRepository<Tag>();
            _handler = new UpdateTagCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var id = 1;
            var name = "Tag1";
            var newName = "Tag2";
            var toUpdate = new Tag
            {
                Id = id,
                Name = name,
            };

            _repository.Add(toUpdate);

            // Act
            var reminderResponse = await _handler.Handle(new UpdateTagCommand { Id = id, Name = newName }, CancellationToken.None);


            // Assert
            Assert.NotNull(reminderResponse);
            Assert.True(reminderResponse.IsSuccess);
            Assert.Equal(toUpdate.Name, newName);
        }
    }
}

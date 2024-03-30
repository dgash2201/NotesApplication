using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Tags.Queries.Get;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Tags
{
    public class GetTagQueryHandlerTests
    {
        private readonly GetTagQueryHandler _handler;
        private readonly IRepository<Tag> _repository;

        public GetTagQueryHandlerTests()
        {
            _repository = new TestRepository<Tag>();
            _handler = new GetTagQueryHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var tag = new Tag()
            {
                Id = 1,
                Name = "tag1"
            };

            _repository.Add(tag);

            // Act
            var tagResponse = await _handler.Handle(new GetTagQuery { Id = tag.Id }, CancellationToken.None);


            // Assert
            Assert.NotNull(tagResponse);
            Assert.True(tagResponse.IsSuccess);
            Assert.Equal(tag.Name, tagResponse.Value.Name);
        }
    }
}

using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;
using InstaConnect.Shared.Business.Exceptions.Posts;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Queries.GetPostById;

public class GetPostByIdQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly GetPostByIdQueryHandler _queryHandler;

    public GetPostByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostByIdQuery(InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostByIdQuery(ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostReadRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostByIdQuery(ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryViewModel>(m => m.Id == ValidId &&
                                              m.UserId == ValidPostCurrentUserId &&
                                              m.UserName == ValidUserName &&
                                              m.UserProfileImage == ValidUserProfileImage &&
                                              m.Title == ValidTitle &&
                                              m.Content == ValidContent);
    }
}

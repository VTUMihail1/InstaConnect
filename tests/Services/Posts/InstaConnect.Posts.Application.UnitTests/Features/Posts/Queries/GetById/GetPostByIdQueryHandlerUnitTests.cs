using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetById;

public class GetPostByIdQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly GetPostByIdQueryBuilder _queryBuilder;
    private readonly GetPostByIdQueryHandler _queryHandler;

    public GetPostByIdQueryHandlerUnitTests()
    {
        _user = SetupUser();
        _post = SetupPost(_user);
        _queryBuilder = new(_post);
        _queryHandler = new(
            InstaConnectMapper,
            PostReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = _queryBuilder.WithInvalidId().Create();

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync();
    }

    [Fact]
    public async Task Handle_ShouldGetPostFromRepository_WhenQueryIsValid()
    {
        // Arrange
        var query = _queryBuilder.Create();

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostReadRepository.ShouldReceiveOneGetByIdAsync(query, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenQueryIsValid()
    {
        // Arrange
        var query = _queryBuilder.Create();

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user);
    }
}

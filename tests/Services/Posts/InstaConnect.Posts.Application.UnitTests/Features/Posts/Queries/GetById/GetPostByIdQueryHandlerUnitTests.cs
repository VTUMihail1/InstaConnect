using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
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
        _user = new UserBuilder().Create();
        _post = new PostBuilder(_user).Create();
        _queryBuilder = new(_post);
        _queryHandler = new(
            PostService,
            ApplicationMapper);

        var request = _queryBuilder.Create();

        PostService.SetupGetByIdRequest(request, _post, _user, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        var response = await _queryHandler.Handle(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        await _queryHandler.Handle(request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneGetByIdAsync(request, CancellationToken);
    }
}

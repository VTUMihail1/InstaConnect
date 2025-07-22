using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly GetAllPostsQueryRequest _request;
    private readonly GetAllPostsQueryRequestBuilder _requestBuilder;

    private readonly GetAllPostsQueryHandler _requestHandler;

    public GetAllPostsQueryHandlerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post, _user);
        _request = _requestBuilder.Create();

        _requestHandler = new(PostService, ApplicationMapper);

        PostService.SetupGetAllRequest(_request, _post, _user, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _requestHandler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _requestHandler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}

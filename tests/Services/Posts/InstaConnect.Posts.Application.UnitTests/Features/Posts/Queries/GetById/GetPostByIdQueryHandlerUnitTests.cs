using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetById;

public class GetPostByIdQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly GetPostByIdQueryRequest _request;
    private readonly GetPostByIdQueryRequestBuilder _requestBuilder;

    private readonly GetPostByIdQueryHandler _requestHandler;

    public GetPostByIdQueryHandlerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

        _requestHandler = new(PostService, ApplicationMapper);

        PostService.SetupGetByIdRequest(_request, _post, _user, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _requestHandler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _requestHandler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}

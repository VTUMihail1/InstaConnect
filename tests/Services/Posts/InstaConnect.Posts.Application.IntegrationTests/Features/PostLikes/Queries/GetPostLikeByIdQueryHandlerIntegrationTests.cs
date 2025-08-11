using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdQueryRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Queries;

public class GetPostLikeByIdQueryHandlerIntegrationTests : BasePostLikeApplicationIntegrationTest
{
    private readonly GetPostLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostLikeByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostLikeByIdQueryRequest _request;

    public GetPostLikeByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Create();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostLikeIdNullWithMessageData]
    [PostLikeIdEmptyWithMessageData]
    [PostLikeIdTooShortWithMessageData]
    [PostLikeIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenLikeIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync(request.Id);
    }

    [Theory]
    [PostLikeIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostLikeNotFoundExceptionAsync(request.Id, request.LikeId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Theory]
    [PostLikeIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }
}

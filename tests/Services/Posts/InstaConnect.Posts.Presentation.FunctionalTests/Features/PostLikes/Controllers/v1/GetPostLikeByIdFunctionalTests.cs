using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.FunctionalTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Presentation.FunctionalTests.Features.PostLikes.Controllers.v1;

public class GetPostLikeByIdFunctionalTests : BasePostLikePresentationFunctionalTest
{
    private readonly GetPostLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostLikeByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostLikeByIdApiRequest _request;

    public GetPostLikeByIdFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostLikeIdNullData]
    [PostLikeIdEmptyData]
    [PostLikeIdTooShortData]
    [PostLikeIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostLikeIdNullWithMessageData]
    [PostLikeIdEmptyWithMessageData]
    [PostLikeIdTooShortWithMessageData]
    [PostLikeIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenLikeIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task GetByIdAsync_ShouldHavePostLikeNotFoundProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeNotFound(request.Id, request.LikeId);
    }

    [Theory]
    [PostLikeIdNotFoundData]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostLikeIdNotFoundData]
    public async Task GetByIdAsync_ShouldHavePostLikeNotFoundProblemDetails_WhenLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeNotFound(request.Id, request.LikeId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostLikeIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostLikeByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Theory]
    [PostLikeIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }
}

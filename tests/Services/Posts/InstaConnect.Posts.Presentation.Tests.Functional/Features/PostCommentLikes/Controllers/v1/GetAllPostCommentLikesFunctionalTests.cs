using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikesFunctionalTests : BasePostCommentLikePresentationFunctionalTest
{
    private readonly GetAllPostCommentLikesApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesApiRequest _request;

    public GetAllPostCommentLikesFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike, User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
    }

    [Theory]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
    }

    [Theory]
    [PostCommentIdTooShortData]
    [PostCommentIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
    }

    [Theory]
    [UserNameTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenUserNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserName(messageTransformer, request);
    }

    [Theory]
    [SortOrderEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
    }

    [Theory]
    [PostCommentLikeSortPropertyEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostCommentLikeSortProperty> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentLikeSortPropertyEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostCommentLikeSortProperty> transformer,
        IEnumMessageTransformer<PostCommentLikeSortProperty> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortProperty(messageTransformer, request);
    }

    [Theory]
    [PostCommentLikePageTooSmallData]
    [PostCommentLikePageTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentLikePageTooSmallWithMessageData]
    [PostCommentLikePageTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
    }

    [Theory]
    [PostCommentLikePageSizeTooSmallData]
    [PostCommentLikePageSizeTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentLikePageSizeTooSmallWithMessageData]
    [PostCommentLikePageSizeTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentLikesProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentNotFound(_request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentLikesAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User, _request);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User, _request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentLikesAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User, _request);
    }
}

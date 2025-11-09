using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsFunctionalTests : BasePostCommentPresentationFunctionalTest
{
    private readonly GetAllPostCommentsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsApiRequest _request;

    public GetAllPostCommentsFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
    }

    [Theory]
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [UserIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [UserNameTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenUserNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentPageEmptyData]
    [PostCommentPageTooSmallData]
    [PostCommentPageTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentPageEmptyWithMessageData]
    [PostCommentPageTooSmallWithMessageData]
    [PostCommentPageTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPage(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [SortOrderEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<SortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(_request.Sorting.Order, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<SortOrder> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(_request.Sorting.Order, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentSortPropertyEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostCommentSortProperty> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(_request.Sorting.Property, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentSortPropertyEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostCommentSortProperty> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(_request.Sorting.Property, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentPageSizeEmptyData]
    [PostCommentPageSizeTooSmallData]
    [PostCommentPageSizeTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentPageSizeEmptyWithMessageData]
    [PostCommentPageSizeTooSmallWithMessageData]
    [PostCommentPageSizeTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

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
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request.Filter.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }
}

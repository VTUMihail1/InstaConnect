using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Controllers.v1;

public class GetAllPostsFunctionalTests : BasePostPresentationFunctionalTest
{
    private readonly GetAllPostsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsApiRequestBuilder _requestBuilder;
    private readonly GetAllPostsApiRequest _request;

    public GetAllPostsFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
    }

    [Theory]
    [UserIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostTitleTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenTitleIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Filter.Title, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostTitleTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenTitleIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Filter.Title, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostPageEmptyData]
    [PostPageTooSmallData]
    [PostPageTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostPageEmptyWithMessageData]
    [PostPageTooSmallWithMessageData]
    [PostPageTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPage(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostSortPropertyEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostSortProperty> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(_request.Sorting.Property, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostSortPropertyEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostSortProperty> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(_request.Sorting.Property, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostPageSizeEmptyData]
    [PostPageSizeTooSmallData]
    [PostPageSizeTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostPageSizeEmptyWithMessageData]
    [PostPageSizeTooSmallWithMessageData]
    [PostPageSizeTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(_request.Pagination.Page, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndTitleAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Filter.Title, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, User, _request);
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
        var response = await HttpClient.GetAllPostsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, User, _request);
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
        var response = await HttpClient.GetAllPostsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, User, _request);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndTitleAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Filter.Title, transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, User, _request);
    }
}

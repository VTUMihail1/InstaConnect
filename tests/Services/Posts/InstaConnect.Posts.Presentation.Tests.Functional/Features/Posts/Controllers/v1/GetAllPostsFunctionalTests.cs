using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Controllers.v1;

public class GetAllPostsFunctionalTests : BasePostPresentationQueryFunctionalTest
{
    private readonly GetAllPostsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsApiRequestBuilder _requestBuilder;
    private readonly GetAllPostsApiRequest _request;

    public GetAllPostsFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
        await ServiceScope.AddPostRangeAsync(Posts, CancellationToken);
    }

    [Theory]
    [UserNameTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserName(messageTransformer, request);
    }

    [Theory]
    [PostTitleTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenTitleIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostTitleTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenTitleIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForTitle(messageTransformer, request);
    }

    [Theory]
    [PostsSortOrderEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostsSortOrderEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
    }

    [Theory]
    [PostsSortTermEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostsSortTermEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostsSortTerm> transformer, IEnumMessageTransformer<PostsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortProperty(messageTransformer, request);
    }

    [Theory]
    [PostPageTooSmallData]
    [PostPageTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostPageTooSmallWithMessageData]
    [PostPageTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
    }

    [Theory]
    [PostPageSizeTooSmallData]
    [PostPageSizeTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostPageSizeTooSmallWithMessageData]
    [PostPageSizeTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
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
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

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
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostsSortOrderAscendingData]
    [PostsSortOrderDescendingData]
    public async Task SendAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostsSortTermCreatedAtData]
    [PostsSortTermTitleData]
    [PostsSortTermUserNameData]
    public async Task SendAsync_ShouldHaveOkStatusCode_WhenRequestAndSortPropertyAreValid(
        IEnumTransformer<PostsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

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
        response.ShouldSatisfy(Posts, _request);
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
        var response = await HttpClient.GetAllPostsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndTitleAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request);
    }

    [Theory]
    [PostsSortOrderWithAscendingTermData]
    [PostsSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request, termTransformer);
    }

    [Theory]
    [PostsSortTermWithCreatedAtTermData]
    [PostsSortTermWithTitleTermData]
    [PostsSortTermWithUserNameTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortPropertyAreValid(
        IEnumTransformer<PostsSortTerm> transformer, ISortEnumTermTransformer<Post> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request, termTransformer);
    }
}

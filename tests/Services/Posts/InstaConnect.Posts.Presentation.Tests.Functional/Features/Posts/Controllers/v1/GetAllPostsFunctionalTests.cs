using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
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
		await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
		await ServiceScope.AddPostRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddPostLikeRangeAsync(PostLikes, CancellationToken);
	}

	[Theory]
	[UserNameTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

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
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserName(messageTransformer, request);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
	}

	[Theory]
	[PostTitleTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenTitleIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

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
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

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
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

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
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
	}

	[Theory]
	[PostsSortTermEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<PostsSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostsSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<PostsSortTerm> transformer, IEnumMessageTransformer<PostsSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
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
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

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
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

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
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

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
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetAllStatusCodeAsync(_request, CancellationToken);

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
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

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
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostsSortOrderAscendingData]
	[PostsSortOrderDescendingData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostsSortTermCreatedAtData]
	[PostsSortTermTitleData]
	[PostsSortTermUserNameData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostsSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetAllAsync(_request, CancellationToken);

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
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, request);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, request);
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
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, request);
	}

	[Theory]
	[PostsSortOrderWithAscendingTermData]
	[PostsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, request, termTransformer);
	}

	[Theory]
	[PostsSortTermWithCreatedAtTermData]
	[PostsSortTermWithTitleTermData]
	[PostsSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostsSortTerm> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, request, termTransformer);
	}
}

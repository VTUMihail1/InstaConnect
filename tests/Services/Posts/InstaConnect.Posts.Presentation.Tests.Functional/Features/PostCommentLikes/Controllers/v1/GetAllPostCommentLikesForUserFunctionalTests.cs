using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikesForUserFunctionalTests : BasePostCommentLikePresentationQueryFunctionalTest
{
	private readonly GetAllPostCommentLikesForUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentLikesForUserApiRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentLikesForUserApiRequest _request;

	public GetAllPostCommentLikesForUserFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
		await ServiceScope.AddPostRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddPostLikeRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddPostCommentRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddPostCommentLikeRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
	}

	[Theory]
	[PostCommentLikesSortOrderEmptyData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentLikesSortOrderEmptyWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
	}

	[Theory]
	[PostCommentLikesForUserSortTermEmptyData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentLikesForUserSortTermEmptyWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer, IEnumMessageTransformer<PostCommentLikesForUserSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
	}

	[Theory]
	[PostCommentLikePageTooSmallData]
	[PostCommentLikePageTooLargeData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentLikePageTooSmallWithMessageData]
	[PostCommentLikePageTooLargeWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await Client.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
	}

	[Theory]
	[PostCommentLikePageSizeTooSmallData]
	[PostCommentLikePageSizeTooLargeData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentLikePageSizeTooSmallWithMessageData]
	[PostCommentLikePageSizeTooLargeWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await Client.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await Client.GetAllForUserProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentLikesSortOrderAscendingData]
	[PostCommentLikesSortOrderDescendingData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentLikesForUserSortTermCreatedAtData]
	[PostCommentLikesForUserSortTermUserNameData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetAllForUserAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, PostCommentLikes, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, PostCommentLikes, request);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, PostCommentLikes, request);
	}

	[Theory]
	[PostCommentLikesSortOrderWithAscendingTermData]
	[PostCommentLikesSortOrderWithDescendingTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, PostCommentLikes, request, termTransformer);
	}

	[Theory]
	[PostCommentLikesForUserSortTermWithCreatedAtTermData]
	[PostCommentLikesForUserSortTermWithUserNameTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, PostCommentLikes, request, termTransformer);
	}
}

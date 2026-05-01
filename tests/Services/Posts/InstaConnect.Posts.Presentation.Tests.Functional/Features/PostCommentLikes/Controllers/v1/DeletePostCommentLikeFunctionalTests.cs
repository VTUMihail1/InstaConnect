namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Controllers.v1;

public class DeletePostCommentLikeFunctionalTests : BasePostCommentLikePresentationCommandFunctionalTest
{
	private readonly DeletePostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommentLikeApiRequestBuilder _requestBuilder;
	private readonly DeletePostCommentLikeApiRequest _request;

	public DeletePostCommentLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddPostAsync(Post, CancellationToken);
		await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await Client.DeleteUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
	}

	[Theory]
	[PostCommentIdTooShortData]
	[PostCommentIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Client.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Client.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Act
		var response = await Client.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Act
		var response = await Client.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentLikeAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostCommentLikeNotFoundProblemDetails_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentLikeAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await Client.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteAsync(_request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(PostCommentLike, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(PostCommentLike, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(PostCommentLike, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(PostCommentLike, CancellationToken);
	}
}

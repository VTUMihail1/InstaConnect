namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Controllers.v1;

public class GetPostCommentByIdFunctionalTests : BasePostCommentPresentationQueryFunctionalTest
{
	private readonly GetPostCommentByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostCommentByIdApiRequestBuilder _requestBuilder;
	private readonly GetPostCommentByIdApiRequest _request;

	public GetPostCommentByIdFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddPostAsync(Post, CancellationToken);
		await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
		await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
	}

	[Theory]
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
	}

	[Theory]
	[PostCommentIdTooShortData]
	[PostCommentIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Act
		var response = await Client.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Act
		var response = await Client.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComment, _request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComment, request);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComment, request);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComment, request);
	}
}

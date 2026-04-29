namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Controllers.v1;

public class AddPostCommentLikeFunctionalTests : BasePostCommentLikePresentationCommandFunctionalTest
{
	private readonly AddPostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentLikeApiRequestBuilder _requestBuilder;
	private readonly AddPostCommentLikeApiRequest _request;

	public AddPostCommentLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeUnauthorizedAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
	}

	[Theory]
	[PostCommentIdTooShortData]
	[PostCommentIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndCommentIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndUserIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(request);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndCommentIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndUserIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, _request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, request);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, request);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(request);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}
}

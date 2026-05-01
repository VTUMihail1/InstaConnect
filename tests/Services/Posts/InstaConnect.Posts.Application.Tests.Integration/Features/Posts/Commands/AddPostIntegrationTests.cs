namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Commands;

public class AddPostIntegrationTests : BasePostApplicationCommandIntegrationTest
{
	private readonly AddPostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommandRequest _request;

	public AddPostIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			messageTransformer, request, CancellationToken);
	}

	[Theory]
	[PostTitleNullWithMessageData]
	[PostTitleEmptyWithMessageData]
	[PostTitleTooShortWithMessageData]
	[PostTitleTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForTitleAsync(
			messageTransformer, request, CancellationToken);
	}

	[Theory]
	[PostContentNullWithMessageData]
	[PostContentEmptyWithMessageData]
	[PostContentTooShortWithMessageData]
	[PostContentTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForContentAsync(
			messageTransformer, request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(post, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(post, request);
	}

	[Fact]
	public async Task SendAsync_ShouldAddPost_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

		// Assert
		post.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddPost_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

		// Assert
		post.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishPostAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostAddedAsync(post, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostAddedAsync(post, CancellationToken);
	}
}

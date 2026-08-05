namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.EmailConfirmationTokens.Controllers;

public class AddEmailConfirmationTokenControllerIntegrationTests : BaseEmailConfirmationTokenPresentationCommandIntegrationTest
{
	private readonly AddEmailConfirmationTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddEmailConfirmationTokenApiRequestBuilder _requestBuilder;
	private readonly AddEmailConfirmationTokenApiRequest _request;

	public AddEmailConfirmationTokenControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNameNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var result = await Controller.AddAsync(_request, CancellationToken);

		// Assert
		result.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var result = await Controller.AddAsync(request, CancellationToken);

		// Assert
		result.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);
		var eventRequests = await EventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);
		var eventRequests = await EventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.EmailConfirmationTokens);
	}
}

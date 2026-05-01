namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Commands;

public class UpdateCurrentUserIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
	private readonly UpdateCurrentUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateCurrentUserCommandRequestBuilder _requestBuilder;
	private readonly UpdateCurrentUserCommandRequest _request;

	public UpdateCurrentUserIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddEmailConfirmationTokenRangeAsync(User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
			messageTransformer, request, CancellationToken);
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForNameAsync(
			messageTransformer, request, CancellationToken);
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			messageTransformer, request, CancellationToken);
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenLastNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForLastNameAsync(
			messageTransformer, request, CancellationToken);
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForEmailAsync(
			messageTransformer, request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserEmailAlreadyTakenException_WhenRequestIsInvalid()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);

		var request = _requestBuilder.WithEmail(user.Email).Build();

		// Assert
		await Sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);

		var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

		// Assert
		await Sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenRequestIsInvalid()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);

		var request = _requestBuilder.WithName(user.Name).Build();

		// Assert
		await Sender.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);

		var request = _requestBuilder.WithName(user.Name, transformer).Build();

		// Assert
		await Sender.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, request);
	}

	[Fact]
	public async Task SendAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(User.EmailConfirmationTokens);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(User.EmailConfirmationTokens);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response.Response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}
}

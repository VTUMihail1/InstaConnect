using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Users.EventHandlers;

public class AddUserPresentationTests : BaseUserPresentationCommandFunctionalTest
{
    private readonly UserAddedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserAddedEventRequestBuilder _requestBuilder;
    private readonly UserAddedEventRequest _request;

    public AddUserPresentationTests(ChatsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameTooShortData]
    [UserNameTooLongData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserFirstNameNullData]
    [UserFirstNameEmptyData]
    [UserFirstNameTooShortData]
    [UserFirstNameTooLongData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenFirstNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserLastNameNullData]
    [UserLastNameEmptyData]
    [UserLastNameTooShortData]
    [UserLastNameTooLongData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenLastNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserEmailNullData]
    [UserEmailEmptyData]
    [UserEmailTooShortData]
    [UserEmailTooLongData]
    [UserEmailInvalidData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenEmailIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserProfileImageTooLongData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenProfileImageIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserCreatedAtUtcEmptyData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenCreatedAtUtcIsInvalid(
        IDateTimeOffsetTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCreatedAtUtc(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserUpdatedAtUtcEmptyData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUpdatedAtUtcIsInvalid(
        IDateTimeOffsetTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenIdAlreadyExists()
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithId(newUser.Id).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenIdIsInvalidAndAlreadyExists(
        IStringTransformer transformer)
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithId(newUser.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenEmailAlreadyExists()
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithEmail(newUser.Email).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenEmailIsInvalidAndAlreadyExists(
        IStringTransformer transformer)
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithEmail(newUser.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenNameAlreadyExists()
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithName(newUser.Name).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenNameIsInvalidAndAlreadyExists(
        IStringTransformer transformer)
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithName(newUser.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task PublishAsync_ShouldNotAddUser_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameTooShortData]
    [UserNameTooLongData]
    public async Task PublishAsync_ShouldNotAddUser_WhenNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserFirstNameNullData]
    [UserFirstNameEmptyData]
    [UserFirstNameTooShortData]
    [UserFirstNameTooLongData]
    public async Task PublishAsync_ShouldNotAddUser_WhenFirstNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserLastNameNullData]
    [UserLastNameEmptyData]
    [UserLastNameTooShortData]
    [UserLastNameTooLongData]
    public async Task PublishAsync_ShouldNotAddUser_WhenLastNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserEmailNullData]
    [UserEmailEmptyData]
    [UserEmailTooShortData]
    [UserEmailTooLongData]
    [UserEmailInvalidData]
    public async Task PublishAsync_ShouldNotAddUser_WhenEmailIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserProfileImageTooLongData]
    public async Task PublishAsync_ShouldNotAddUser_WhenProfileImageIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserCreatedAtUtcEmptyData]
    public async Task PublishAsync_ShouldNotAddUser_WhenCreatedAtUtcIsInvalid(
        IDateTimeOffsetTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCreatedAtUtc(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserUpdatedAtUtcEmptyData]
    public async Task PublishAsync_ShouldNotAddUser_WhenUpdatedAtUtcIsInvalid(
        IDateTimeOffsetTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Fact]
    public async Task PublishAsync_ShouldNotAddUser_WhenEmailAlreadyExists()
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithEmail(newUser.Email).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task PublishAsync_ShouldNotAddUser_WhenEmailIsInvalidAndAlreadyExists(
        IStringTransformer transformer)
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithEmail(newUser.Email, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Fact]
    public async Task PublishAsync_ShouldNotAddUser_WhenNameAlreadyExists()
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithName(newUser.Name).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task PublishAsync_ShouldNotAddUser_WhenNameIsInvalidAndAlreadyExists(
        IStringTransformer transformer)
    {
        // Arrange
        var newUser = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(newUser, CancellationToken);
        var request = _requestBuilder.WithName(newUser.Name, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Fact]
    public async Task PublishAsync_ShouldConsumeUserAddedEvent_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(_request, CancellationToken);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task PublishAsync_ShouldConsumeUserAddedEvent_WhenProfileImageIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldAddUser_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task PublishAsync_ShouldAddUser_WhenProfileImageIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithProfileImage(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }
}

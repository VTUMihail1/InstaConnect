using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Users.EventHandlers;

public class UpdateUserPresentationTests : BaseUserPresentationCommandFunctionalTest
{
    private readonly UserUpdatedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserUpdatedEventRequestBuilder _requestBuilder;
    private readonly UserUpdatedEventRequest _request;

    public UpdateUserPresentationTests(PostsWebApplicationFactory webApplicationFactory)
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
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenIdIsInvalid(
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
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenNameIsInvalid(
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
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenFirstNameIsInvalid(
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
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenLastNameIsInvalid(
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
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenEmailIsInvalid(
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
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenProfileImageIsInvalid(
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
    [UserUpdatedAtUtcEmptyData]
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenUpdatedAtUtcIsInvalid(
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
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenIdNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenEmailAlreadyExists()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithEmail(user).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenEmailIsInvalidAndAlreadyExists(
        IStringTransformer transformer)
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithEmail(user, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenNameAlreadyExists()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithName(user).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenNameIsInvalidAndAlreadyExists(
        IStringTransformer transformer)
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithName(user, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(_request, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenNameHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithName(User).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(User, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenEmailIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenEmailHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenProfileImageIsValid(
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
    public async Task PublishAsync_ShouldUpdateUser_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task PublishAsync_ShouldUpdateUser_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(_request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task PublishAsync_ShouldUpdateUser_WhenNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Fact]
    public async Task PublishAsync_ShouldUpdateUser_WhenNameHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithName(User).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task PublishAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(User, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task PublishAsync_ShouldUpdateUser_WhenEmailIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Fact]
    public async Task PublishAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserEmailDifferentCaseData]
    public async Task PublishAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithEmail(User, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(request);
    }

    [Theory]
    [UserProfileImageNullData]
    [UserProfileImageEmptyData]
    public async Task PublishAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
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

using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Users.EventHandlers;

public class AddUserPresentationTests : BaseUserPresentationFunctionalTest
{
    private readonly UserAddedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserAddedEventRequestBuilder _requestBuilder;
    private readonly UserAddedEventRequest _request;

    public AddUserPresentationTests(PostsWebApplicationFactory webApplicationFactory)
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
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithId(user).Build();

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
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithId(user, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenEmailAlreadyExists()
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
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenEmailIsInvalidAndAlreadyExists(
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
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenNameAlreadyExists()
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
    public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenNameIsInvalidAndAlreadyExists(
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

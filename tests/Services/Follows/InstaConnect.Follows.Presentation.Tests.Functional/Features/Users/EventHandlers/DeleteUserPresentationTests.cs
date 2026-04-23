using InstaConnect.Follows.Tests.Features.Common.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Users.EventHandlers;

public class DeleteUserPresentationTests : BaseUserPresentationCommandFunctionalTest
{
    private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserDeletedEventRequestBuilder _requestBuilder;
    private readonly UserDeletedEventRequest _request;

    public DeleteUserPresentationTests(FollowsWebApplicationFactory webApplicationFactory)
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
    public async Task PublishAsync_ShouldFaultUserDeletedEvent_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldFaultUserDeletedEvent_WhenIdNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveFaultedAsync(_request, CancellationToken);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task PublishAsync_ShouldNotDeleteUser_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldSatisfy(User);
    }

    [Fact]
    public async Task PublishAsync_ShouldConsumeUserDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(_request, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task PublishAsync_ShouldConsumeUserDeletedEvent_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHaveConsumedAsync(request, CancellationToken);
    }

    [Fact]
    public async Task PublishAsync_ShouldDeleteUser_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task PublishAsync_ShouldDeleteUser_WhenIdIsValid(
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
}

using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Commands;

public class DeleteFollowIntegrationTests : BaseFollowApplicationCommandIntegrationTest
{
    private readonly DeleteFollowCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteFollowCommandRequestBuilder _requestBuilder;
    private readonly DeleteFollowCommandRequest _request;

    public DeleteFollowIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Follow);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(Follower, CancellationToken);
        await ServiceScope.AddUserAsync(Following, CancellationToken);
        await ServiceScope.AddFollowAsync(Follow, CancellationToken);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenFollowerIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenFollowingIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowFollowNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteFollowAsync(Follow, CancellationToken);

        // Assert
        await Sender.ShouldThrowFollowNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteFollow_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(Follow.Id, CancellationToken);

        // Assert
        follow.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeleteFollow_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(Follow.Id, CancellationToken);

        // Assert
        follow.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeleteFollow_WhenRequestAndFollowingIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var follow = await ServiceScope.GetFollowByIdAsync(Follow.Id, CancellationToken);

        // Assert
        follow.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishFollowDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedFollowDeletedAsync(Follow, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishFollowDeletedEvent_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedFollowDeletedAsync(Follow, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishFollowDeletedEvent_WhenRequestAndFollowingIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedFollowDeletedAsync(Follow, CancellationToken);
    }
}

using InstaConnect.Common.Events.Models;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Commands;

public class DeleteUserClaimIntegrationTests : BaseUserClaimApplicationCommandIntegrationTest
{
    private readonly DeleteUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserClaimCommandRequestBuilder _requestBuilder;
    private readonly DeleteUserClaimCommandRequest _request;

    public DeleteUserClaimIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(UserClaim);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);
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
        await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserClaimClaimEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenClaimIsInvalid(
        IEnumTransformer<ApplicationClaims> transformer, IEnumMessageTransformer<ApplicationClaims> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithClaim(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForClaimAsync(messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserClaimNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserClaimAsync(UserClaim, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserClaimNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteUserClaim_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(UserClaim.Id, CancellationToken);

        // Assert
        userClaim.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeleteUserClaim_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var userClaim = await ServiceScope.GetUserClaimByIdAsync(UserClaim.Id, CancellationToken);

        // Assert
        userClaim.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserClaimDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(UserClaim, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishUserClaimDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(UserClaim, CancellationToken);
    }
}

using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

using Xunit.Sdk;

namespace InstaConnect.Users.Application.PresentationTests.Features.Users.Commands;

public class DeleteUserPresentationTests : BaseUserPresentationFunctionalTest
{
    private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserDeletedEventRequestBuilder _requestBuilder;
    private readonly UserDeletedEventRequest _request;

    public DeleteUserPresentationTests(PostsWebApplicationFactory webApplicationFactory)
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
    public async Task SendAsync_ShouldHaveErrorMessage_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserDeletedEventRequestAsync(request, errorMessage, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldHaveUserNotFoundErrorMessage_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasFaulted = await EventHarness.HasFaultedUserDeletedEventRequestWithNotFoundMessageAsync(_request, CancellationToken);

        // Assert
        eventWasFaulted.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldConsumeUserDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var eventWasConsumed = await EventHarness.HasConsumedUserDeletedEventRequestAsync(_request, CancellationToken);

        // Assert
        eventWasConsumed.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldConsumeUserDeletedEvent_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(request, CancellationToken);
        var eventWasConsumed = await EventHarness.HasConsumedUserDeletedEventRequestAsync(request, CancellationToken);

        // Assert
        eventWasConsumed.ShouldBeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteUser_WhenRequestIsValid()
    {
        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeleteUser_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await EventHarness.PublishAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }
}

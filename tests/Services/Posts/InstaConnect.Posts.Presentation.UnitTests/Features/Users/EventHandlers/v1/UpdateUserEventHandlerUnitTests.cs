using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class UpdateUserEventHandlerUnitTests : BaseUserPresentationUnitTest
{
    private readonly UserUpdatedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserUpdatedEventRequestBuilder _requestBuilder;
    private readonly UserUpdatedEventRequest _request;

    private readonly UserUpdatedEventHandler _handler;

    public UpdateUserEventHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task Consume_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Consume(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}

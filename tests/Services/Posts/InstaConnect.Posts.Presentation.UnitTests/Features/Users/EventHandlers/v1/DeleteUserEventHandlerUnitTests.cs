using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class DeleteUserEventHandlerUnitTests : BaseUserPresentationUnitTest
{
    private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserDeletedEventRequestBuilder _requestBuilder;
    private readonly UserDeletedEventRequest _request;

    private readonly UserDeletedEventHandler _handler;

    public DeleteUserEventHandlerUnitTests()
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

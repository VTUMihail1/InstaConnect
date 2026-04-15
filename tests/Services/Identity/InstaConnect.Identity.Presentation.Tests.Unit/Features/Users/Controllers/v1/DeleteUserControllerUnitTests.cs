namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;


public class DeleteUserControllerUnitTests : BaseUserPresentationCommandUnitTest
{
    private readonly DeleteUserApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserApiRequestBuilder _requestBuilder;
    private readonly DeleteUserApiRequest _request;

    private readonly UserController _controller;

    public DeleteUserControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.DeleteAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}

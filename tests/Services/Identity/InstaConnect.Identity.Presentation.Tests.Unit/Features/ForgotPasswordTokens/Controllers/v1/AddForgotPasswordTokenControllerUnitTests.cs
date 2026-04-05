namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.ForgotPasswordTokens.Controllers.v1;

public class AddForgotPasswordTokenControllerUnitTests : BaseForgotPasswordTokenPresentationCommandUnitTest
{
    private readonly AddForgotPasswordTokenApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddForgotPasswordTokenApiRequestBuilder _requestBuilder;
    private readonly AddForgotPasswordTokenApiRequest _request;

    private readonly ForgotPasswordTokenController _controller;

    public AddForgotPasswordTokenControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.AddAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}

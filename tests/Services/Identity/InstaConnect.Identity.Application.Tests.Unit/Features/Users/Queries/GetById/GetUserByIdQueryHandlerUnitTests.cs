namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Queries.GetById;

public class GetUserByIdQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
    private readonly GetUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetUserByIdQueryRequestBuilder _requestBuilder;
    private readonly GetUserByIdQueryRequest _request;

    private readonly GetUserByIdQueryHandler _handler;

    public GetUserByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupGetByIdQuery(_request, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await Service.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}

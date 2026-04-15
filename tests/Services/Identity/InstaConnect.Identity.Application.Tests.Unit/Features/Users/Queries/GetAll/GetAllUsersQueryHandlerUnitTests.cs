namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Queries.GetAll;

public class GetAllUsersQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
    private readonly GetAllUsersQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllUsersQueryRequestBuilder _requestBuilder;
    private readonly GetAllUsersQueryRequest _request;

    private readonly GetAllUsersQueryHandler _handler;

    public GetAllUsersQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupGetAllQuery(_request, Users, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await Service.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}

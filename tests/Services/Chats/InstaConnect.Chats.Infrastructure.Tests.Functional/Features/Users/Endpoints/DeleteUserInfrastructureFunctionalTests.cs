using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Functional.Features.Users.Endpoints;

public class DeleteUserInfrastructureFunctionalTests : BaseUserInfrastructureCommandFunctionalTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	public DeleteUserInfrastructureFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
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
		var eventRequest = await EventHarness.FaultedDeletedEventRequestAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserDeletedEvent_WhenIdNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		await EventHarness.PublishAsync(_request, CancellationToken);
		var eventRequest = await EventHarness.FaultedDeletedEventRequestAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task PublishAsync_ShouldConsumeUserDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await EventHarness.PublishAsync(_request, CancellationToken);
		var eventRequest = await EventHarness.FaultedDeletedEventRequestAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
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
		var eventRequest = await EventHarness.ConsumedDeletedEventRequestAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await EventHarness.PublishAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

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
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}
}

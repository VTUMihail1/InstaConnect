using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class GetChatByIdCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	private readonly ChatIdBuilderFactory _idBuilderFactory;
	private readonly ChatIdBuilder _idBuilder;
	private readonly ChatId _id;

	private readonly ChatInclude _include;

	public GetChatByIdCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(Chat.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandIsValid()
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Chat);
	}
}

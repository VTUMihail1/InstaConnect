using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Queries;

public class GetChatByIdIntegrationTests : BaseChatDomainQueryIntegrationTest
{
	private readonly GetChatByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetChatByIdQueryBuilder _queryBuilder;
	private readonly GetChatByIdQuery _query;

	public GetChatByIdIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Chat);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddUserAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, _query);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, query);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, query);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, query);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(ParticipantOne.Id, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, query);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, query);
	}
}

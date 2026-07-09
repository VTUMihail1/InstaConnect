using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortOrder;
using InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortTerm;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Queries;

public class GetAllChatsIntegrationTests : BaseChatDomainQueryIntegrationTest
{
	private readonly GetAllChatsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllChatsQueryBuilder _queryBuilder;
	private readonly GetAllChatsQuery _query;

	public GetAllChatsIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Chat);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddUserRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddChatRangeAsync(Chats, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowUserNotFoundException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(ParticipantOne, CancellationToken);

		// Assert
		await Service.ShouldThrowParticipantOneNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(ParticipantOne, Chats, _query);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(ParticipantOne, Chats, query);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(ParticipantOne, Chats, query);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(ParticipantOne, Chats, query, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(ParticipantOne, Chats, query, termTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ParticipantTwo, Chats, query);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoName(ParticipantOne.Name, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ParticipantTwo, Chats, query);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ParticipantTwo, Chats, query);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ParticipantTwo, Chats, query, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ParticipantTwo, Chats, query, termTransformer);
	}
}

using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class GetFollowsForFollowingTotalCountQueryRepositoryIntegrationTests : BaseFollowInfrastructureQueryIntegrationTest
{
	private readonly FollowsForFollowingFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly FollowsForFollowingFilterQueryBuilder _filterQueryBuilder;
	private readonly FollowsForFollowingFilterQuery _filterQuery;

	public GetFollowsForFollowingTotalCountQueryRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Follow);
		_filterQuery = _filterQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountForFollowingAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountForFollowingAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountForFollowingAsync_ShouldReturnResponse_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountForFollowingAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Follows);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetTotalCountForFollowingAsync_ShouldReturnResponse_WhenQueryAndFollowerNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountForFollowingAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Follows);
	}
}

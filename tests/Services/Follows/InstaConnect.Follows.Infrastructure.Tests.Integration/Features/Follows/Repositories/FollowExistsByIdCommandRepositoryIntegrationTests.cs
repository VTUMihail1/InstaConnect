using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class FollowExistsByIdCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	private readonly FollowIdBuilderFactory _idBuilderFactory;
	private readonly FollowIdBuilder _idBuilder;
	private readonly FollowId _id;

	public FollowExistsByIdCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(Follow.Id);
		_id = _idBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id);
	}
}

using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class FollowExistsByIdQueryRepositoryIntegrationTests : BaseFollowInfrastructureQueryIntegrationTest
{
	private readonly FollowIdBuilderFactory _idBuilderFactory;
	private readonly FollowIdBuilder _idBuilder;
	private readonly FollowId _id;

	public FollowExistsByIdQueryRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(Follow.Id);
		_id = _idBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, follow);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, follow);
	}
}

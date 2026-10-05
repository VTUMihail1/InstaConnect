using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class PostLikeExistsByIdQueryRepositoryUnitTests : BasePostLikeInfrastructureQueryUnitTest
{
	private readonly PostLikeIdBuilderFactory _idBuilderFactory;
	private readonly PostLikeIdBuilder _idBuilder;
	private readonly PostLikeId _id;

	private readonly PostLikeQueryRepository _repository;

	public PostLikeExistsByIdQueryRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(PostLike.Id);
		_id = _idBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory, LikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupMatch(_id);
		Fluent.SetupAnyAsync(_id, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(_id, CancellationToken);
	}
}

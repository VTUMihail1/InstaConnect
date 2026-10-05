using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class PostCommentLikeExistsByIdCommandRepositoryUnitTests : BasePostCommentLikeInfrastructureCommandUnitTest
{
	private readonly PostCommentLikeIdBuilderFactory _idBuilderFactory;
	private readonly PostCommentLikeIdBuilder _idBuilder;
	private readonly PostCommentLikeId _id;

	private readonly PostCommentLikeCommandRepository _repository;

	public PostCommentLikeExistsByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(PostCommentLike.Id);
		_id = _idBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupMatch(_id);
		Fluent.SetupAnyAsync(_id, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, PostCommentLike);
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

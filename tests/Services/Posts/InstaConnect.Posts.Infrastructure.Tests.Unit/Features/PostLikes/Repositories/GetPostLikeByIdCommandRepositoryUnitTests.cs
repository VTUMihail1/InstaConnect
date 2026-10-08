using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class GetPostLikeByIdCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeIdBuilderFactory _idBuilderFactory;
	private readonly PostLikeIdBuilder _idBuilder;
	private readonly PostLikeId _id;

	private readonly PostLikeInclude _include;

	private readonly PostLikeCommandRepository _repository;

	public GetPostLikeByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(PostLike.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().WithPost().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupApplyIncludes(_id, _include);
		Fluent.SetupMatch(_id);
		Fluent.SetupFirstOrDefaultAsync(_id, PostLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, PostLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_id, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(_id, CancellationToken);
	}
}

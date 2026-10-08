using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class GetPostCommentLikeByIdQueryRepositoryUnitTests : BasePostCommentLikeInfrastructureQueryUnitTest
{
	private readonly PostCommentLikeIdBuilderFactory _idBuilderFactory;
	private readonly PostCommentLikeIdBuilder _idBuilder;
	private readonly PostCommentLikeId _id;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostCommentLikeInclude _include;

	private readonly PostCommentLikeQueryRepository _repository;

	public GetPostCommentLikeByIdQueryRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(PostCommentLike.Id);
		_id = _idBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = CommentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(CommentIncludeBuilderFactory.Create().WithUser().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().Build()).WithPostCommentLikes().Build()).Build();

		_repository = new(Collection, IncludeBuilderFactory, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(_id, _currentUserQuery, _include);
		Fluent.SetupMatch(_id, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(_id, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(_id, _currentUserQuery, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, _currentUserQuery, PostCommentLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_id, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentResponseFirstOrDefaultAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(_id, _currentUserQuery, CancellationToken);
	}
}

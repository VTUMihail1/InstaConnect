using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class GetPostCommentLikeByIdQueryServiceUnitTests : BasePostCommentLikeDomainQueryUnitTest
{
	private readonly GetPostCommentLikeByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetPostCommentLikeByIdQueryBuilder _queryBuilder;
	private readonly GetPostCommentLikeByIdQuery _query;

	private readonly PostCommentLikeQueryService _service;

	public GetPostCommentLikeByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostCommentLike);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CommentLikeRepository, CollectionResponseFactory);

		Repository.SetupExistsById(_query, CancellationToken);
		CommentRepository.SetupExistsById(_query, CancellationToken);
		CommentLikeRepository.SetupGetById(_query, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveExistsById(_query, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
	{
		// Arrange
		CommentRepository.RemoveExistsById(_query, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostCommentLikeNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		CommentLikeRepository.RemoveGetById(_query, PostCommentLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentLikeNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, PostCommentLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentRepositoryExistsByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneExistsByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCommentLikeRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}
}

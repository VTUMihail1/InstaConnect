using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class GetAllPostCommentLikesServiceUnitTests : BasePostCommentLikeDomainQueryUnitTest
{
	private readonly GetAllPostCommentLikesQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentLikesQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentLikesQuery _query;

	private readonly PostCommentLikeQueryService _service;

	public GetAllPostCommentLikesServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostCommentLike);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CommentLikeRepository, CollectionResponseFactory);

		Repository.SetupExistsById(_query, CancellationToken);
		CommentRepository.SetupGetById(_query, PostComment, CancellationToken);
		CommentLikeRepository.SetupGetAllQuery(_query, PostCommentLikes, CancellationToken);
		CommentLikeRepository.SetupGetTotalCount(_query, PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveExistsById(_query, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
	{
		// Arrange
		CommentRepository.RemoveGetById(_query, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComment, PostCommentLikes, _query);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCommentLikeRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCommentLikeRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneGetTotalCountAsync(_query, CancellationToken);
	}
}

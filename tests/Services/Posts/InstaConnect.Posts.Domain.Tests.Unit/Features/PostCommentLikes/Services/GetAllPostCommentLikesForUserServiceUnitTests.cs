using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class GetAllPostCommentLikesForUserServiceUnitTests : BasePostCommentLikeDomainQueryUnitTest
{
	private readonly GetAllPostCommentLikesForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentLikesForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentLikesForUserQuery _query;

	private readonly PostCommentLikeQueryService _service;

	public GetAllPostCommentLikesForUserServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostCommentLike);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CommentLikeRepository, CollectionResponseFactory);

		UserRepository.SetupGetById(_query, User, CancellationToken);
		CommentLikeRepository.SetupGetAllForUserQuery(_query, PostCommentLikes, CancellationToken);
		CommentLikeRepository.SetupGetTotalCountForUser(_query, PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetById(_query, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, PostCommentLikes, _query);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCommentLikeRepositoryGetAllForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneGetAllForUserAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCommentLikeRepositoryGetTotalCountForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneGetTotalCountForUserAsync(_query, CancellationToken);
	}
}

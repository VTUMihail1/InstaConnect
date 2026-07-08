using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Queries;

public class GetAllPostCommentsForUserUnitTests : BasePostCommentDomainQueryUnitTest
{
	private readonly GetAllPostCommentsForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentsForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentsForUserQuery _query;

	private readonly PostCommentQueryService _service;

	public GetAllPostCommentsForUserUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CollectionResponseFactory);

		UserRepository.SetupGetById(_query, User, CancellationToken);
		CommentRepository.SetupGetAllForUserQuery(_query, PostComments, CancellationToken);
		CommentRepository.SetupGetTotalCountForUser(_query, PostComments, CancellationToken);
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
		response.ShouldSatisfy(User, PostComments, _query);
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
	public async Task GetAllForUserAsync_ShouldCallTheCommentRepositoryGetAllForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetAllForUserAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCommentRepositoryGetTotalCountForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetTotalCountForUserAsync(_query, CancellationToken);
	}
}

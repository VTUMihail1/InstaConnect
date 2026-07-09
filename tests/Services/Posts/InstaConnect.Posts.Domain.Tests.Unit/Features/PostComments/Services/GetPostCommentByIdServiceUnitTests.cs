using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Services;

public class GetPostCommentByIdServiceUnitTests : BasePostCommentDomainQueryUnitTest
{
	private readonly GetPostCommentByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetPostCommentByIdQueryBuilder _queryBuilder;
	private readonly GetPostCommentByIdQuery _query;

	private readonly PostCommentQueryService _service;

	public GetPostCommentByIdServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CollectionResponseFactory);

		Repository.SetupExistsById(_query, CancellationToken);
		CommentRepository.SetupGetById(_query, PostComment, CancellationToken);
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
	public async Task GetByIdAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentDoesNotExist()
	{
		// Arrange
		CommentRepository.RemoveGetById(_query, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComment, _query);
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
	public async Task GetByIdAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}
}

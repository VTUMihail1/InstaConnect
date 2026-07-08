using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Queries;

public class GetAllPostCommentsUnitTests : BasePostCommentDomainQueryUnitTest
{
	private readonly GetAllPostCommentsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentsQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentsQuery _query;

	private readonly PostCommentQueryService _service;

	public GetAllPostCommentsUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CollectionResponseFactory);

		Repository.SetupGetById(_query, Post, CancellationToken);
		CommentRepository.SetupGetAllQuery(_query, PostComments, CancellationToken);
		CommentRepository.SetupGetTotalCount(_query, PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetById(_query, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Post, PostComments, _query);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCommentRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCommentRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetTotalCountAsync(_query, CancellationToken);
	}
}

using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class PostCommentExistsByIdCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	private readonly PostCommentIdBuilderFactory _idBuilderFactory;
	private readonly PostCommentIdBuilder _idBuilder;
	private readonly PostCommentId _id;

	public PostCommentExistsByIdCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(PostComment.Id);
		_id = _idBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, postComment);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, postComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, postComment);
	}
}

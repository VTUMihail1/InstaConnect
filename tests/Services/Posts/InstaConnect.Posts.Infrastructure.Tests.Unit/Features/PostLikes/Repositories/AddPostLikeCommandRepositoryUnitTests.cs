using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class AddPostLikeCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeCommandRepository _repository;

	public AddPostLikeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.AddAsync(PostLike, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostLike, CancellationToken);
	}
}

using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class AddPostLikeCommandRepositoryIntegrationTests : BasePostLikeInfrastructureCommandIntegrationTest
{
	public AddPostLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostLike_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostLike, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLike.Id, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(PostLike);
	}
}

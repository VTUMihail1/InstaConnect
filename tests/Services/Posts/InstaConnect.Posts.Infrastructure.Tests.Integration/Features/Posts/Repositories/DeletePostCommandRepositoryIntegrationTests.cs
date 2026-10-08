using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class DeletePostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public DeletePostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(Post.Id, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}
}

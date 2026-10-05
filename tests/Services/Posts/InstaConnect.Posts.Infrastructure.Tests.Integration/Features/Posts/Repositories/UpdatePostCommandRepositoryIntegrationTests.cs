using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class UpdatePostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public UpdatePostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePost_WhenCommandIsValid()
	{
		var updatedPost = PostBuilderFactory.Create(User).WithId(Post.Id).Build();

		// Act
		await Repository.UpdateAsync(updatedPost, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(Post.Id, CancellationToken);

		// Assert
		post.ShouldSatisfy(updatedPost);
	}
}

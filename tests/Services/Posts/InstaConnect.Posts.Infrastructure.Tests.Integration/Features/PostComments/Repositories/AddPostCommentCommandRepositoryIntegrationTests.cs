using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class AddPostCommentCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	public AddPostCommentCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostComment.Id, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(PostComment);
	}
}

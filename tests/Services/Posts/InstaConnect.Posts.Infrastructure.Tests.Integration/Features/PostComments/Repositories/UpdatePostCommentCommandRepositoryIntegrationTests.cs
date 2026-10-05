using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class UpdatePostCommentCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	public UpdatePostCommentCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandIsValid()
	{
		var updatedPostComment = PostCommentBuilderFactory.Create(Post, User).WithId(PostComment.Id).Build();

		// Act
		await Repository.UpdateAsync(updatedPostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostComment.Id, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(updatedPostComment);
	}
}

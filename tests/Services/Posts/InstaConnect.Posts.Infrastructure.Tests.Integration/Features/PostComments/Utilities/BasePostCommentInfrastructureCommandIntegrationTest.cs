using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureCommandIntegrationTest : BasePostCommentWebTest
{
	protected IPostCommentCommandRepository Repository { get; }

	protected IPostCommentIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetPostCommentIncludeBuilderFactory();

	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
	}
}

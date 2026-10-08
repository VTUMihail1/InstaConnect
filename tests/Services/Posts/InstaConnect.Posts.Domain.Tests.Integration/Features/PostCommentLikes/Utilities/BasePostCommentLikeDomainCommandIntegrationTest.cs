using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeDomainCommandIntegrationTest : BasePostCommentLikeWebTest
{
	protected IPostCommentLikeCommandService Service { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected BasePostCommentLikeDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostCommentLikeCommandService();
		CommentLikeEventClient = webApplicationFactory.CreateCommentLikeEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CancellationToken);
		await CommentLikeEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentLikeEventClient.StopAsync(CancellationToken);
	}
}

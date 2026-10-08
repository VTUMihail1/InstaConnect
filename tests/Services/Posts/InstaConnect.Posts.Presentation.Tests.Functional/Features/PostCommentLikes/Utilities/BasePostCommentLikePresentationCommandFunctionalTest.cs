using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandFunctionalTest : BasePostCommentLikeWebTest
{
	protected IPostCommentLikeApiClient CommentLikeApiClient { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected BasePostCommentLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CommentLikeApiClient = webApplicationFactory.CreateCommentLikeApiClient();
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

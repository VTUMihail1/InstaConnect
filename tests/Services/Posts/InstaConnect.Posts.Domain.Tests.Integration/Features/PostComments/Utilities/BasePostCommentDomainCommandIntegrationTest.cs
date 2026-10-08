using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentDomainCommandIntegrationTest : BasePostCommentWebTest
{
	protected IPostCommentCommandService Service { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected BasePostCommentDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostCommentCommandService();
		CommentEventClient = webApplicationFactory.CreateCommentEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await CommentEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentEventClient.StopAsync(CancellationToken);
	}
}

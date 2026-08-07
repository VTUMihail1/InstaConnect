using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

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

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await CommentEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await CommentEventClient.StopAsync(CancellationToken);
	}
}

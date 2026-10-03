using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationCommandFunctionalTest : BasePostCommentWebTest
{
	protected IPostCommentApiClient CommentApiClient { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected BasePostCommentPresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CommentApiClient = webApplicationFactory.CreateCommentApiClient();
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

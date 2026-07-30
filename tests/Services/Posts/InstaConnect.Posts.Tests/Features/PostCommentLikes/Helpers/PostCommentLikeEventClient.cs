using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Helpers;

public class PostCommentLikeEventClient : IPostCommentLikeEventClient
{
	private readonly IEventHarness _eventHarness;

	public PostCommentLikeEventClient(IEventHarness eventHarness)
	{
		_eventHarness = eventHarness;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await _eventHarness.StartAsync(cancellationToken);
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _eventHarness.StopAsync(cancellationToken);
	}

	public async Task<PostCommentLikeAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostCommentLikeAddedEventRequest>(cancellationToken);
	}

	public async Task<PostCommentLikeDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostCommentLikeDeletedEventRequest>(cancellationToken);
	}
}

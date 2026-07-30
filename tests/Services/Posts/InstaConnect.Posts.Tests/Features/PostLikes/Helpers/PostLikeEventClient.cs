using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Helpers;

public class PostLikeEventClient : IPostLikeEventClient
{
	private readonly IEventHarness _eventHarness;

	public PostLikeEventClient(IEventHarness eventHarness)
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

	public async Task<PostLikeAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostLikeAddedEventRequest>(cancellationToken);
	}

	public async Task<PostLikeDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostLikeDeletedEventRequest>(cancellationToken);
	}
}

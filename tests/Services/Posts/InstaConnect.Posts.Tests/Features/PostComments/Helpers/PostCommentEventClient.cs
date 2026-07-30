using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Helpers;

public class PostCommentEventClient : IPostCommentEventClient
{
	private readonly IEventHarness _eventHarness;

	public PostCommentEventClient(IEventHarness eventHarness)
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

	public async Task<PostCommentAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostCommentAddedEventRequest>(cancellationToken);
	}

	public async Task<PostCommentUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostCommentUpdatedEventRequest>(cancellationToken);
	}

	public async Task<PostCommentDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostCommentDeletedEventRequest>(cancellationToken);
	}
}

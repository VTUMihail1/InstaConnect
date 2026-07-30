using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Tests.Features.Posts.Helpers;

public class PostEventClient : IPostEventClient
{
	private readonly IEventHarness _eventHarness;

	public PostEventClient(IEventHarness eventHarness)
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

	public async Task<PostAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostAddedEventRequest>(cancellationToken);
	}

	public async Task<PostUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostUpdatedEventRequest>(cancellationToken);
	}

	public async Task<PostDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<PostDeletedEventRequest>(cancellationToken);
	}
}

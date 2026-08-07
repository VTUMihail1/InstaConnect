using System.Threading.Channels;

using InstaConnect.Follows.Presentation.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;

using Microsoft.AspNetCore.SignalR.Client;

namespace InstaConnect.Follows.Tests.Features.Follows.Helpers;

public class FollowNotificationClient : IFollowNotificationClient
{
	private readonly HubConnection _connection;
	private readonly Channel<FollowAddedNotificationRequest> _addedChannel = Channel.CreateUnbounded<FollowAddedNotificationRequest>();

	public FollowNotificationClient(HubConnection connection)
	{
		_connection = connection;
		_connection.On<FollowAddedNotificationRequest>(nameof(IFollowHubClient.Added), request =>
			_addedChannel.Writer.TryWrite(request));
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await _connection.StartAsync(cancellationToken);
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _connection.StopAsync(cancellationToken);
	}

	public async Task<FollowAddedNotificationRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		const int Timeout = 10;

		return await _addedChannel.Reader.ReadAsync(cancellationToken).AsTask().WaitAsync(TimeSpan.FromSeconds(Timeout), cancellationToken);
	}
}

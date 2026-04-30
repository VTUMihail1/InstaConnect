using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Presentation.Features.Follows.Abstractions;

public interface IFollowHubClient
{
	public Task Added(FollowAddedNotificationRequest request);
}

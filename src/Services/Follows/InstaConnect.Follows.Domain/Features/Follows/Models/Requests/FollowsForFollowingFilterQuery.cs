namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsForFollowingFilterQuery(
	UserId FollowingId,
	Name FollowerName);

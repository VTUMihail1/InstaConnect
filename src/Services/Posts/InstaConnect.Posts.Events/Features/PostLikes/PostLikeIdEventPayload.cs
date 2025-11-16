namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeIdEventPayload(PostIdEventPayload Id, UserIdEventPayload UserId);

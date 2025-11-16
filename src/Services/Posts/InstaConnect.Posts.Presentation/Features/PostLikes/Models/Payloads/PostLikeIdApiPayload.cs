namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Payloads;

public record PostLikeIdApiPayload(PostIdApiPayload Id, UserIdApiPayload UserId);

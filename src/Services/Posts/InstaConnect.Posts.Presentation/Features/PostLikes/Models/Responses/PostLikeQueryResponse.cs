namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record PostLikeQueryResponse(string Id, string PostId, string UserId, string UserName, string? UserProfileImage);

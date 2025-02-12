namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeQueryResponse(string Id, string PostCommentId, string UserId, string UserName, string? UserProfileImage);

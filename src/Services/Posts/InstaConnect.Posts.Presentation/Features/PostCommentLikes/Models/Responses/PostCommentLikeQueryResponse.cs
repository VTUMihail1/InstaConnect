namespace InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeQueryResponse(string Id, string PostCommentId, string UserId, string UserName, string? UserProfileImage);

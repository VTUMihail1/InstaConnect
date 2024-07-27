namespace InstaConnect.Posts.Web.Models.Responses.PostCommentLikes;

public record PostCommentLikeQueryResponse(string Id, string PostCommentId, string UserId, string UserName, string? UserProfileImage);

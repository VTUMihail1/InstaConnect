namespace InstaConnect.Posts.Web.Models.Responses.PostComments;

public record PostCommentQueryResponse(string Id, string Content, string PostId, string UserId, string UserName, string? UserProfileImage);

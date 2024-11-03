namespace InstaConnect.Posts.Web.Features.PostComments.Models.Responses;

public record PostCommentQueryResponse(string Id, string Content, string PostId, string UserId, string UserName, string? UserProfileImage);

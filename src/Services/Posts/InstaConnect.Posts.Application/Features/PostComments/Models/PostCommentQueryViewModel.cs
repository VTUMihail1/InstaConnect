namespace InstaConnect.Posts.Business.Features.PostComments.Models;

public record PostCommentQueryViewModel(string Id, string Content, string PostId, string UserId, string UserName, string? UserProfileImage);

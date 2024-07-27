namespace InstaConnect.Posts.Business.Models.PostComment;

public record PostCommentQueryViewModel(string Id, string Content, string PostId, string UserId, string UserName, string? UserProfileImage);

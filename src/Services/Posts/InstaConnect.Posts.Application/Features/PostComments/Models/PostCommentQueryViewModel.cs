namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQueryViewModel(string Id, string Content, string PostId, string UserId, string UserName, string? UserProfileImage);

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryViewModel(string Id, string PostCommentId, string UserId, string UserName, string? UserProfileImage);

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryViewModel(string Id, string PostCommentId, string UserId, string UserName, string? UserProfileImage);

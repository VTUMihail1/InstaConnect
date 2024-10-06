namespace InstaConnect.Posts.Business.Features.PostLikes.Models;

public record PostLikeQueryViewModel(string Id, string PostId, string UserId, string UserName, string? UserProfileImage);

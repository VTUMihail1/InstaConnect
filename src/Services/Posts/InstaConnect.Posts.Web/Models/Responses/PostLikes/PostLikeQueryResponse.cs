namespace InstaConnect.Posts.Read.Web.Models.Responses;

public record PostLikeQueryResponse(string Id, string PostId, string UserId, string UserName, string? UserProfileImage);

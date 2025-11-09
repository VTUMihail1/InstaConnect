namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostApiResponse(string Id, string Title, string Content, PostUserApiResponse User);

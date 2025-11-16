namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostApiResponse(PostIdApiPayload Id, string Title, string Content, PostUserApiResponse User);

namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryResponse(PostIdPayload Id, string Title, string Content, PostUserQueryResponse User);

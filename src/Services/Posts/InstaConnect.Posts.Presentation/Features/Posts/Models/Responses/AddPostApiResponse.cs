namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record AddPostApiResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);

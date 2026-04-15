namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsForUserFilterQuery(
    UserId UserId,
    string Title);

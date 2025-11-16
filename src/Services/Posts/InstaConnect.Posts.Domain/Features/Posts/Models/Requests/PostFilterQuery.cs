namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostFilterQuery(
    UserId UserId,
    Name UserName,
    string Title);

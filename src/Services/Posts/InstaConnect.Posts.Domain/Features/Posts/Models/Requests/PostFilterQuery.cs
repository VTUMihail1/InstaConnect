namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostFilterQuery(
    Name UserName,
    string Title);

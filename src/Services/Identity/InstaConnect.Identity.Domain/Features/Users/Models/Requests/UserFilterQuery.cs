namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record UserFilterQuery(
    string FirstName,
    string LastName,
    string Name);

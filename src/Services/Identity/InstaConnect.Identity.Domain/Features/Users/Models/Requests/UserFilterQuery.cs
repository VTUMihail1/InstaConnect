namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UserFilterQuery(
    string FirstName,
    string LastName,
    string Name);

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UsersFilterQuery(
    string FirstName,
    string LastName,
    Name Name);

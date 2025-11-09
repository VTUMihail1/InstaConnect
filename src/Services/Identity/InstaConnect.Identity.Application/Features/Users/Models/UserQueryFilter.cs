namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserQueryFilter(
    string FirstName,
    string LastName,
    string Name);

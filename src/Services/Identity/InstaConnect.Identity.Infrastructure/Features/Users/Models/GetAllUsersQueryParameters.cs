namespace InstaConnect.Users.Infrastructure.Features.Users.Models;

public record GetAllUsersQueryParameters(
    string FirstName,
    string LastName,
    string Name,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);

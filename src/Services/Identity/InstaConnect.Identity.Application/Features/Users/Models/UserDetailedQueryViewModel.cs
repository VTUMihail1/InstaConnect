namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserDetailedQueryViewModel(string Id, string FirstName, string LastName, string UserName, string Email, string? ProfileImage);

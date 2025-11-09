using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UpdateUserCommand(
    string Id,
    string Email,
    string FirstName,
    string LastName,
    string Name,
    IFormFile? ProfileImage);

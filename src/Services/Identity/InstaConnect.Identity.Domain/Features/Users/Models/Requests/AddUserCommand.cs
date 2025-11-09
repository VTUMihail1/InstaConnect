using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record AddUserCommand(
    string Name,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage);

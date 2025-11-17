using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record AddUserCommand(
    Name Name,
    Email Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage);

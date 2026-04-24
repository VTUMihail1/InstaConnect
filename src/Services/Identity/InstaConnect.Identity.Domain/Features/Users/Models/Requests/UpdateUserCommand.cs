using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UpdateUserCommand(
    UserId Id,
    Email Email,
    string FirstName,
    string LastName,
    Name Name,
    IFormFile? ProfileImage);

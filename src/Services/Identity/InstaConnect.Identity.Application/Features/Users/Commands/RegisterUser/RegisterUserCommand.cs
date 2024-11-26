using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.RegisterUser;

public record RegisterUserCommand(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage) : ICommand<UserCommandViewModel>;

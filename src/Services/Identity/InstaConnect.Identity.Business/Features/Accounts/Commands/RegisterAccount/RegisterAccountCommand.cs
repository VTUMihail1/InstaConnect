using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;

public record RegisterAccountCommand(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage) : ICommand<AccountCommandViewModel>;

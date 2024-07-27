using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Business.Commands.Account.RegisterAccount;

public record RegisterAccountCommand(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage) : ICommand<AccountCommandViewModel>;

using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;

public class EditCurrentAccountProfileImageCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;

    public IFormFile ProfileImage { get; set; }
}

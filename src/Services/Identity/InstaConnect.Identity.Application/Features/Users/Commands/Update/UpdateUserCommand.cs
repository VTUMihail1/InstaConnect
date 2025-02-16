﻿using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Update;

public record UpdateUserCommand(string CurrentUserId, string FirstName, string LastName, string UserName, IFormFile? ProfileImageFile) : ICommand<UserCommandViewModel>;

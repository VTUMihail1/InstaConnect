using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;

using System;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenFactory
{
    public EmailConfirmationToken Create(string id);
}

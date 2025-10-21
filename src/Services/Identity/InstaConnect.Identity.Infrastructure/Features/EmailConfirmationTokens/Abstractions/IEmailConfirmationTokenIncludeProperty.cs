using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeProperty : IIncludeProperty<EmailConfirmationToken>
{
    public EmailConfirmationTokenIncludeProperty IncludeProperty { get; }
}

using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

internal interface IEmailConfirmationTokenIncluder : IIncluder<EmailConfirmationToken, IdentityIncludeType, IdentityDestinationType>;

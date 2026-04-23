using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

internal interface IEmailConfirmationTokenIncluderFactory
    : IIncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IEmailConfirmationTokenIncluder, EmailConfirmationToken>;

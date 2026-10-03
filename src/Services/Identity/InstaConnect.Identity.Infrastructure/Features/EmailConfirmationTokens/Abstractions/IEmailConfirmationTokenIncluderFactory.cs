using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncluderFactory
	: IIncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IEmailConfirmationTokenIncluder, EmailConfirmationToken>;

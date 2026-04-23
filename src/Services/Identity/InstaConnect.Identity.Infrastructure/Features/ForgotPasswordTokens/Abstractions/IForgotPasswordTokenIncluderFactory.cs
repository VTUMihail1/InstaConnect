using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

internal interface IForgotPasswordTokenIncluderFactory
    : IIncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IForgotPasswordTokenIncluder, ForgotPasswordToken>;

using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeDescriptorFactory
{
    IdentityIncludeDescriptor CreateUser();
}

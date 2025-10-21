using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IForgotPasswordTokenIncludePropertyFactory
{
    ICollection<IForgotPasswordTokenIncludeProperty> Create(ICollection<ForgotPasswordTokenIncludeProperty>? includeProperties);
}

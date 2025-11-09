namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludePropertyFactory
{
    IEnumerable<IForgotPasswordTokenIncludeProperty> Create(ICollection<ForgotPasswordTokenIncludeProperty>? includeProperties);
}

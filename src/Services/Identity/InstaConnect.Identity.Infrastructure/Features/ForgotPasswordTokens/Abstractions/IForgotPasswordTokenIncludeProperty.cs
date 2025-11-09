namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeProperty : IIncludeProperty<ForgotPasswordToken>
{
    public ForgotPasswordTokenIncludeProperty IncludeProperty { get; }
}

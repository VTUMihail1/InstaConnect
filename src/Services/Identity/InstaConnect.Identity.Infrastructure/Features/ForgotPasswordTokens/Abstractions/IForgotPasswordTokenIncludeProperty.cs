namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeProperty : IIncluder<ForgotPasswordToken>
{
    public ForgotPasswordTokenIncludeProperty IncludeProperty { get; }
}

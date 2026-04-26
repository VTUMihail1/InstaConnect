using InstaConnect.Common.Domain.Features.Emails.Abstractions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenEmailSender : IForgotPasswordTokenEmailSender
{
    private readonly IEmailSender _emailSender;
    private readonly IForgotPasswordTokenSendEmailRequestFactory _forgotPasswordTokenSendEmailRequestFactory;

    public ForgotPasswordTokenEmailSender(
        IEmailSender emailSender,
        IForgotPasswordTokenSendEmailRequestFactory forgotPasswordTokenSendEmailRequestFactory)
    {
        _emailSender = emailSender;
        _forgotPasswordTokenSendEmailRequestFactory = forgotPasswordTokenSendEmailRequestFactory;
    }

    public async Task SendAsync(ForgotPasswordToken forgotPasswordToken, CancellationToken cancellationToken)
    {
        var request = _forgotPasswordTokenSendEmailRequestFactory.Get(forgotPasswordToken);

        await _emailSender.SendAsync(request, cancellationToken);
    }
}

using InstaConnect.Emails.Business.Features.Emails.Abstractions;
using InstaConnect.Emails.Business.Features.Emails.Models.Emails;
using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Emails.Business.Features.Emails.Helpers;

internal class EmailHandler : IEmailHandler
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailFactory _emailFactory;
    private readonly IEmailEndpointHandler _emailEndpointHandler;

    public EmailHandler(
        IEmailSender emailSender,
        IEmailFactory emailFactory,
        IEmailEndpointHandler emailEndpointHandler)
    {
        _emailSender = emailSender;
        _emailFactory = emailFactory;
        _emailEndpointHandler = emailEndpointHandler;
    }

    public async Task SendEmailConfirmationAsync(SendConfirmEmailModel sendConfirmEmailModel, CancellationToken cancellationToken)
    {
        var endpoint = _emailEndpointHandler.GetEmailConfirmationEndpoint(sendConfirmEmailModel.UserId, sendConfirmEmailModel.Token);
        var emailContent = _emailFactory.GetEmail(sendConfirmEmailModel.Email, sendConfirmEmailModel.Title, endpoint);

        try
        {
            await _emailSender.SendEmailAsync(emailContent, cancellationToken);
        }
        catch (Exception exception)
        {
            throw new BadRequestException(exception.Message, exception);
        }
    }

    public async Task SendForgotPasswordAsync(SendForgotPasswordModel sendForgotPasswordModel, CancellationToken cancellationToken)
    {
        var endpoint = _emailEndpointHandler.GetForgotPasswordEndpoint(sendForgotPasswordModel.UserId, sendForgotPasswordModel.Token);
        var emailContent = _emailFactory.GetEmail(sendForgotPasswordModel.Email, sendForgotPasswordModel.Title, endpoint);

        try
        {
            await _emailSender.SendEmailAsync(emailContent, cancellationToken);
        }
        catch (Exception exception)
        {
            throw new BadRequestException(exception.Message, exception);
        }
    }
}

using InstaConnect.Emails.Business.Features.Emails.Abstractions;
using InstaConnect.Emails.Business.Features.Emails.Utilities;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Exceptions.Base;
using MassTransit;

namespace InstaConnect.Emails.Business.Features.Emails.Consumers;

public class UserConfirmEmailTokenCreatedEventConsumer : IConsumer<UserConfirmEmailTokenCreatedEvent>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailFactory _emailFactory;

    public UserConfirmEmailTokenCreatedEventConsumer(
        IEmailSender emailSender,
        IEmailFactory emailFactory)
    {
        _emailSender = emailSender;
        _emailFactory = emailFactory;
    }

    public async Task Consume(ConsumeContext<UserConfirmEmailTokenCreatedEvent> context)
    {
        var emailContent = _emailFactory.GetEmail(context.Message.Email, EmailConstants.ForgotPasswordTitle, context.Message.RedirectUrl);

        try
        {
            await _emailSender.SendEmailAsync(emailContent, context.CancellationToken);
        }
        catch (Exception exception)
        {
            throw new BadRequestException(exception.Message, exception);
        }
    }
}

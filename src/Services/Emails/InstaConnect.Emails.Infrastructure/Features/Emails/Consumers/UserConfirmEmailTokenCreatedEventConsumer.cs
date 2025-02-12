using InstaConnect.Emails.Application.Features.Emails.Abstractions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Utilities;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Common.Exceptions.Base;
using MassTransit;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Consumers;

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

using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Emails.Application.Features.Emails.Abstractions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

using MassTransit;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Consumers;

public class UserConfirmEmailTokenCreatedEventConsumer : IConsumer<EmailConfirmationTokenAddedEventRequest>
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

    public async Task Consume(ConsumeContext<EmailConfirmationTokenAddedEventRequest> context)
    {
        var mailMessage = _emailFactory.GetEmail(context.Message.EmailConfirmationToken.Value, EmailConstants.ForgotPasswordTitle, context.Message.EmailConfirmationToken.Id);

        try
        {
            await _emailSender.SendEmailAsync(mailMessage, context.CancellationToken);
        }
        catch (Exception exception)
        {
            throw new BadRequestException(exception.Message, exception);
        }
    }
}

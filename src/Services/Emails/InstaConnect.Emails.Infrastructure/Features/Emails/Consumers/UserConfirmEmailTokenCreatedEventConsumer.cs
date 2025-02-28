using InstaConnect.Common.Application.Contracts.EmailConfirmationTokens;
using InstaConnect.Common.Exceptions.Base;
using InstaConnect.Emails.Application.Features.Emails.Abstractions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Utilities;

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
        var mailMessage = _emailFactory.GetEmail(context.Message.Email, EmailConstants.ForgotPasswordTitle, context.Message.RedirectUrl);

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

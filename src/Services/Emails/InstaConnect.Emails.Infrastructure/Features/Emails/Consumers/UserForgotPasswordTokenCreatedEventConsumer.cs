using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Emails.Application.Features.Emails.Abstractions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Utilities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

using MassTransit;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Consumers;

public class UserForgotPasswordTokenCreatedEventConsumer : IConsumer<ForgotPasswordTokenAddedEventRequest>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailFactory _emailFactory;

    public UserForgotPasswordTokenCreatedEventConsumer(
        IEmailSender emailSender,
        IEmailFactory emailFactory)
    {
        _emailSender = emailSender;
        _emailFactory = emailFactory;
    }

    public async Task Consume(ConsumeContext<ForgotPasswordTokenAddedEventRequest> context)
    {
        var mailMessage = _emailFactory.GetEmail(context.Message.Id, EmailConstants.ForgotPasswordTitle, context.Message.Id);

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

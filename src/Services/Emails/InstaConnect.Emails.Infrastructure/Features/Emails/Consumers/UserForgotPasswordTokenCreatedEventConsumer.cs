﻿using InstaConnect.Emails.Application.Features.Emails.Abstractions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Utilities;
using InstaConnect.Shared.Application.Contracts.ForgotPasswordTokens;
using InstaConnect.Shared.Common.Exceptions.Base;

using MassTransit;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Consumers;

public class UserForgotPasswordTokenCreatedEventConsumer : IConsumer<UserForgotPasswordTokenCreatedEvent>
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

    public async Task Consume(ConsumeContext<UserForgotPasswordTokenCreatedEvent> context)
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

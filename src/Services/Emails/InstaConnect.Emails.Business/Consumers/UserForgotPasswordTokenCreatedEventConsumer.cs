using AutoMapper;
using InstaConnect.Emails.Business.Abstract;
using InstaConnect.Emails.Business.Models.Emails;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using MassTransit;

namespace InstaConnect.Emails.Business.Consumers;

public class UserForgotPasswordTokenCreatedEventConsumer : IConsumer<UserForgotPasswordTokenCreatedEvent>
{
    private readonly IEmailHandler _emailHandler;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UserForgotPasswordTokenCreatedEventConsumer(
        IEmailHandler emailHandler,
        IInstaConnectMapper instaConnectMapper)
    {
        _emailHandler = emailHandler;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task Consume(ConsumeContext<UserForgotPasswordTokenCreatedEvent> context)
    {
        var sendForgotPasswordModel = _instaConnectMapper.Map<SendForgotPasswordModel>(context.Message);

        await _emailHandler.SendForgotPasswordAsync(sendForgotPasswordModel, context.CancellationToken);
    }
}

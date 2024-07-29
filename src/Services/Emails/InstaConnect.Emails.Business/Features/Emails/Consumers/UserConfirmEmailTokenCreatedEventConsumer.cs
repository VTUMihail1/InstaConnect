using InstaConnect.Emails.Business.Features.Emails.Abstractions;
using InstaConnect.Emails.Business.Features.Emails.Models.Emails;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using MassTransit;

namespace InstaConnect.Emails.Business.Features.Emails.Consumers;

public class UserConfirmEmailTokenCreatedEventConsumer : IConsumer<UserConfirmEmailTokenCreatedEvent>
{
    private readonly IEmailHandler _emailHandler;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UserConfirmEmailTokenCreatedEventConsumer(
        IEmailHandler emailHandler,
        IInstaConnectMapper instaConnectMapper)
    {
        _emailHandler = emailHandler;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task Consume(ConsumeContext<UserConfirmEmailTokenCreatedEvent> context)
    {
        var sendConfirmEmailModel = _instaConnectMapper.Map<SendConfirmEmailModel>(context.Message);

        await _emailHandler.SendEmailConfirmationAsync(sendConfirmEmailModel, context.CancellationToken);
    }
}

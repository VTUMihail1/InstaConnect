using AutoMapper;
using InstaConnect.Emails.Business.Abstract;
using InstaConnect.Emails.Business.Models.Emails;
using InstaConnect.Shared.Business.Contracts.Emails;
using MassTransit;

namespace InstaConnect.Emails.Business.Consumers;

public class UserForgotPasswordTokenCreatedEventConsumer : IConsumer<UserForgotPasswordTokenCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IEmailHandler _emailHandler;

    public UserForgotPasswordTokenCreatedEventConsumer(
        IMapper mapper,
        IEmailHandler emailHandler)
    {
        _mapper = mapper;
        _emailHandler = emailHandler;
    }

    public async Task Consume(ConsumeContext<UserForgotPasswordTokenCreatedEvent> context)
    {
        var sendForgotPasswordModel = _mapper.Map<SendForgotPasswordModel>(context.Message);

        await _emailHandler.SendForgotPasswordAsync(sendForgotPasswordModel, context.CancellationToken);
    }
}

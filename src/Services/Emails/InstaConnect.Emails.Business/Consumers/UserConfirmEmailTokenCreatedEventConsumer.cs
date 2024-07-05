using AutoMapper;
using InstaConnect.Emails.Business.Abstract;
using InstaConnect.Emails.Business.Models.Emails;
using InstaConnect.Shared.Business.Contracts.Emails;
using MassTransit;

namespace InstaConnect.Emails.Business.Consumers;

public class UserConfirmEmailTokenCreatedEventConsumer : IConsumer<UserConfirmEmailTokenCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IEmailHandler _emailHandler;

    public UserConfirmEmailTokenCreatedEventConsumer(
        IMapper mapper, 
        IEmailHandler emailHandler)
    {
        _mapper = mapper;
        _emailHandler = emailHandler;
    }

    public async Task Consume(ConsumeContext<UserConfirmEmailTokenCreatedEvent> context)
    {
        var sendConfirmEmailModel = _mapper.Map<SendConfirmEmailModel>(context.Message);

        await _emailHandler.SendEmailConfirmationAsync(sendConfirmEmailModel, context.CancellationToken);
    }
}

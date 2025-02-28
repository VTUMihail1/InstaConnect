using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Messages.Infrastructure.Features.Messages.Helpers;
internal class MessageService : IMessageService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public MessageService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public void Update(Message message, string content)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        message.Update(content, utcNow);
    }
}

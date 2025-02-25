
using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Messages.Infrastructure.Features.Messages.Helpers;
internal class MessageFactory : IMessageFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public MessageFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public Message Get(string senderId, string receiverId, string content)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var message = new Message(
            id,
            content,
            senderId,
            receiverId,
            utcNow,
            utcNow);

        return message;
    }
}

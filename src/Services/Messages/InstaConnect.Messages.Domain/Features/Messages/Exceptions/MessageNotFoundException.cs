using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Messages.Domain.Features.Messages.Exceptions;

public class MessageNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Message not found";

    public MessageNotFoundException() : base(ErrorMessage)
    {
    }

    public MessageNotFoundException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}

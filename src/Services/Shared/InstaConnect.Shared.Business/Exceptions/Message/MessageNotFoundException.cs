using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Message;

public class MessageNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "Message not found";

    public MessageNotFoundException() : base(ERROR_MESSAGE)
    {
    }

    public MessageNotFoundException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}

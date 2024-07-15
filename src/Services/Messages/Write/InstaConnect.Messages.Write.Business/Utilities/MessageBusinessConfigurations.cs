using InstaConnect.Messages.Write.Business.Abstract;

namespace InstaConnect.Messages.Write.Business.Utilities;

internal class MessageBusinessConfigurations
{
    public const int ID_MIN_LENGTH = 7;
    public const int ID_MAX_LENGTH = 100;

    public const int CONTENT_MIN_LENGTH = 5;
    public const int CONTENT_MAX_LENGTH = 3000;

    public const int CURRENT_USER_ID_MIN_LENGTH = 7;
    public const int CURRENT_USER_ID_MAX_LENGTH = 100;

    public const int RECEIVER_ID_MIN_LENGTH = 7;
    public const int RECEIVER_ID_MAX_LENGTH = 100;
}

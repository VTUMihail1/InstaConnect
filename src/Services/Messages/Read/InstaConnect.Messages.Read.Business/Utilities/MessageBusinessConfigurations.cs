namespace InstaConnect.Messages.Read.Business.Utilities;

internal class MessageBusinessConfigurations
{
    public const int ID_MIN_LENGTH = 7;
    public const int ID_MAX_LENGTH = 100;

    public const int CURRENT_USER_ID_MIN_LENGTH = 7;
    public const int CURRENT_USER_ID_MAX_LENGTH = 100;

    public const int RECEIVER_ID_MIN_LENGTH = 7;
    public const int RECEIVER_ID_MAX_LENGTH = 100;

    public const int RECEIVER_NAME_MIN_LENGTH = 7;
    public const int RECEIVER_NAME_MAX_LENGTH = 100;

    public const int LIMIT_MIN_VALUE = 0;
    public const int LIMIT_MAX_VALUE = int.MaxValue;

    public const int OFFSET_MIN_VALUE = 0;
    public const int OFFSET_MAX_VALUE = int.MaxValue;

    public const int SORT_PROPERTY_NAME_MIN_LENGTH = 7;
    public const int SORT_PROPERTY_NAME_MAX_LENGTH = 100;

    public const int SORT_ORDER_MIN_LENGTH = 7;
    public const int SORT_ORDER_MAX_LENGTH = 100;
}

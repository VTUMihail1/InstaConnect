namespace InstaConnect.Common.Domain.Utilities;
public static class CommonErrorMessages
{
    public static string GetSortOrderEmpty()
    {
        const string Message = "Sort order must not be empty.";

        return Message;
    }
}

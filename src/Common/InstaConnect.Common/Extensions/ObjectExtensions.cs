namespace InstaConnect.Common.Extensions;

public static class ObjectExtensions
{
    public static bool IsNull(this object? obj)
    {
        var result = obj is null;

        return result;
    }

    public static bool IsNotNull(this object? obj)
    {
        var result = obj is not null;

        return result;
    }
}

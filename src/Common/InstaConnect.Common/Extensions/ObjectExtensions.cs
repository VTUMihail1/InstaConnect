namespace InstaConnect.Common.Extensions;

public static class ObjectExtensions
{
    public static bool EqualsNull(this object? obj)
    {
        var result = Equals(obj, null);

        return result;
    }
}

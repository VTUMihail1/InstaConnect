namespace InstaConnect.Common.Extensions;

public static class IntExtensions
{
    public static int Increment(this int value)
    {
        return value + 1;
    }

    public static int Decrement(this int value)
    {
        return value - 1;
    }
}

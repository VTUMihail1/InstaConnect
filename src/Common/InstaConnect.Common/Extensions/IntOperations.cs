namespace InstaConnect.Common.Extensions;

public static class IntOperations
{
    public static int Increment(int value)
    {
        return value + 1;
    }

    public static int Decrement(int value)
    {
        return value - 1;
    }

    public static int Average(int max, int min)
    {
        return (max - min) / 2;
    }
}

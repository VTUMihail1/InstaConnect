using System.Linq.Expressions;

using FluentAssertions;

namespace InstaConnect.Common.Tests.Assertions;

public static class MatchAssertions
{
    public static void ShouldSatisfy<T>(this T obj, Expression<Func<T, bool>> predicate)
    {
        obj.Should().Match(predicate);
    }

    public static void ShouldBeNull<T>(this T obj)
    {
        obj.Should().BeNull();
    }

    public static void ShouldBe<T>(this T obj, T value)
    {
        obj.Should().Be(value);
    }

    public static void ShouldBeTrue(this bool obj)
    {
        obj.Should().Be(true);
    }

    public static void ShouldBeFalse(this bool obj)
    {
        obj.Should().Be(false);
    }

    public static void ShouldContain<T>(this IEnumerable<T> obj, Expression<Func<T, bool>> predicate)
    {
        obj.Should().Contain(predicate);
    }
}

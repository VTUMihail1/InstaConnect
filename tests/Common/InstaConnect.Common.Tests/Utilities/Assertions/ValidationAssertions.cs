using System.Linq.Expressions;

using FluentValidation.TestHelper;

using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.Utilities.Assertions;

public static class ValidationAssertions
{
    public static void ShouldHaveValidationErrorForProperty<T, TProperty>(this TestValidationResult<T> testValidationResult, Expression<Func<T, TProperty>> memberAccessor, string errorMessage)
    {
        testValidationResult
            .ShouldHaveValidationErrorFor(memberAccessor)
            .ShouldContain(p => p.IsSatisfied(errorMessage));
    }

    public static void ShouldNotHaveAnyValidationErrorProperties<T>(this TestValidationResult<T> testValidationResult)
    {
        testValidationResult.ShouldNotHaveAnyValidationErrors();
    }
}

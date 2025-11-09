using System.Linq.Expressions;

using FluentValidation.TestHelper;

namespace InstaConnect.Common.Application.Tests.Assertions;

public static class ValidationAssertions
{
    public static void ShouldHaveValidationErrorForProperty<T, TProperty>(this TestValidationResult<T> testValidationResult, Expression<Func<T, TProperty>> memberAccessor, string errorMessage)
    {
        testValidationResult
            .ShouldHaveValidationErrorFor(memberAccessor)
            .ShouldContain(p => p.ErrorMessage == errorMessage);
    }

    public static void ShouldNotHaveAnyValidationErrorProperties<T>(this TestValidationResult<T> testValidationResult)
    {
        testValidationResult.ShouldNotHaveAnyValidationErrors();
    }
}

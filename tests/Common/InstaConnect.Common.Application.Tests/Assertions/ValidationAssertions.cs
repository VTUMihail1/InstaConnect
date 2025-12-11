using System.Linq.Expressions;

using FluentValidation.TestHelper;

using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Common.Application.Tests.Assertions;

public static class ValidationAssertions
{
    public static void ShouldHaveValidationErrorForProperty<TRequest, TProperty>(
        this TestValidationResult<TRequest> testValidationResult,
        Expression<Func<TRequest, TProperty>> memberAccessor,
        IMessageTransformer<TProperty> messageTransformer,
        TRequest request)
    {
        testValidationResult
            .ShouldHaveValidationErrorFor(memberAccessor)
            .ShouldContain(p => p.Matches(messageTransformer.Transform(memberAccessor, memberAccessor.Compile()(request))));
    }

    public static void ShouldNotHaveAnyValidationErrorProperties<T>(this TestValidationResult<T> testValidationResult)
    {
        testValidationResult.ShouldNotHaveAnyValidationErrors();
    }
}

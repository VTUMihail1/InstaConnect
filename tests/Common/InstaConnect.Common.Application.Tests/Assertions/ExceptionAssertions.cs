using System.Linq.Expressions;

using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Base;

using MediatR;

namespace InstaConnect.Common.Application.Tests.Assertions;

public static class ExceptionAssertions
{
    public static async Task ShouldThrowInvalidValidationExceptionAsync<TRequest, TValue>(
        this IApplicationSender sender,
        Expression<Func<TRequest, TValue>> propertyExpression,
        IMessageTransformer<TValue> messageTransformer,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        var action = () => sender.SendAsync(request, cancellationToken);

        await action.ShouldThrowAsync<InvalidValidationException>(
            CommonExceptionErrorMessages.GetInvalidValidation(),
            ex => ex.Errors
                    .All(a => a == messageTransformer.Transform(propertyExpression, propertyExpression.Compile()(request)))
                    .ShouldBeTrue());
    }

    public static async Task ShouldThrowInvalidValidationExceptionAsync<TRequest, TValue, TResponse>(
        this IApplicationSender sender,
        Expression<Func<TRequest, TValue>> propertyExpression,
        IMessageTransformer<TValue> messageTransformer,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        var action = () => sender.SendAsync(request, cancellationToken);

        await action.ShouldThrowAsync<InvalidValidationException>(
            CommonExceptionErrorMessages.GetInvalidValidation(),
            ex => ex.Errors
                    .All(a => a == messageTransformer.Transform(propertyExpression, propertyExpression.Compile()(request)))
                    .ShouldBeTrue());
    }

    public static async Task ShouldThrowAsync<TException, TRequest>(
        this IApplicationSender sender,
        string errorMessage,
        TRequest request,
        CancellationToken cancellationToken)
        where TException : Exception
        where TRequest : IRequest
    {
        var action = () => sender.SendAsync(request, cancellationToken);

        await action.ShouldThrowAsync<TException>(errorMessage);
    }

    public static async Task ShouldThrowAsync<TException, TRequest, TResponse>(
        this IApplicationSender sender,
        string errorMessage,
        TRequest request,
        CancellationToken cancellationToken)
        where TException : Exception
        where TRequest : IRequest<TResponse>
    {
        var action = () => sender.SendAsync(request, cancellationToken);

        await action.ShouldThrowAsync<TException>(errorMessage);
    }
}

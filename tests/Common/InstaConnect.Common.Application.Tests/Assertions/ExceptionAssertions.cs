using System.Linq.Expressions;

using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Base;

using MediatR;

namespace InstaConnect.Common.Application.Tests.Assertions;

public static class ExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionAsync<TRequest, TValue>(
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

        public async Task ShouldThrowInvalidValidationExceptionAsync<TRequest, TValue, TResponse>(
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

        public async Task ShouldThrowAsync<TException, TRequest>(
            string errorMessage,
            TRequest request,
            CancellationToken cancellationToken)
            where TException : Exception
            where TRequest : IRequest
        {
            var action = () => sender.SendAsync(request, cancellationToken);

            await action.ShouldThrowAsync<TException>(errorMessage);
        }

        public async Task ShouldThrowAsync<TException, TRequest, TResponse>(
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
}

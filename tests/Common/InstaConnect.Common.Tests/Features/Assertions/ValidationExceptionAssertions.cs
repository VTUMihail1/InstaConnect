using System.Linq.Expressions;

using FluentAssertions;

using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.ExceptionHandling.Utilities;

namespace InstaConnect.Common.Tests.Features.Assertions;

public static class ValidationExceptionAssertions
{
	extension(Func<Task> action)
	{
		public async Task ShouldThrowInvalidValidationExceptionAsync<TRequest, TValue>(
			Expression<Func<TRequest, TValue>> propertyExpression,
			IMessageTransformer<TValue> messageTransformer,
			TRequest request,
			CancellationToken cancellationToken)
		{
			var exception = await action.Should().ThrowAsync<InvalidValidationException>().WithMessage(CommonExceptionErrorMessages.GetInvalidValidation());

			exception
				.Which
				.Errors
				.All(a => a == messageTransformer.Transform(propertyExpression, propertyExpression.Compile()(request))).ShouldBeTrue();
		}
	}
}

using System.Linq.Expressions;

using FluentAssertions;

using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.ExceptionHandling.Utilities;

namespace InstaConnect.Common.Tests.Features.Assertions;

public static class ValidationExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowInvalidValidationExceptionAsync<TRequest, TValue>(
			TRequest request,
			Expression<Func<TRequest, TValue>> propertyExpression,
			IMessageTransformer<TValue> messageTransformer,
			CancellationToken cancellationToken)
		{
			var exception = await func.Should().ThrowAsync<InvalidValidationException>().WithMessage(CommonExceptionErrorMessages.GetInvalidValidation());

			exception
				.Which
				.Errors
				.All(a => a == messageTransformer.Transform(propertyExpression, propertyExpression.Compile()(request))).ShouldBeTrue();
		}
	}
}

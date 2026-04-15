using System.Linq.Expressions;

using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Presentation.Models;
using InstaConnect.Common.Presentation.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Tests.Assertions;

public static class ProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        internal void ShouldSatisfy(int statusCode, string errorMessage)
        {
            problemDetails.ShouldSatisfy(d => d.Matches(statusCode, errorMessage));
        }

        public void ShouldSatisfyInvalidValidation<TRequest, TProperty>(
            Expression<Func<TRequest, TProperty>> propertyExpression,
            IMessageTransformer<TProperty> messageTransformer,
            TRequest request)
        {
            problemDetails.ShouldSatisfy(d => d.Matches(
                StatusCodes.Status400BadRequest,
                CommonExceptionErrorMessages.GetInvalidValidation(),
                messageTransformer.Transform(propertyExpression, propertyExpression.Compile()(request))));
        }

        public void ShouldSatisfyBadRequest(string errorMessage)
        {
            problemDetails.ShouldSatisfy(StatusCodes.Status400BadRequest, errorMessage);
        }

        public void ShouldSatisfyForbidden(string errorMessage)
        {
            problemDetails.ShouldSatisfy(StatusCodes.Status403Forbidden, errorMessage);
        }

        public void ShouldSatisfyNotFound(string errorMessage)
        {
            problemDetails.ShouldSatisfy(StatusCodes.Status404NotFound, errorMessage);
        }
    }
}

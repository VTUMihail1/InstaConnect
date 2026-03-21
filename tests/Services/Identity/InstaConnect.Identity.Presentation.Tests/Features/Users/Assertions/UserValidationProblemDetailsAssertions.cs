using InstaConnect.Common.Presentation.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFirstName(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FirstName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForLastName(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.LastName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForName(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Name,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForEmail(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Email,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            DeleteUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetUserByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetUserByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetCurrentUserByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetUserDetailsByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetUserDetailsByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetCurrentUserDetailsByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFirstName(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FirstName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForLastName(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.LastName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForName(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Name,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForEmail(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Email,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPassword(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Password,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForConfirmPassword(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.ConfirmPassword,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForName(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Name,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFirstName(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FirstName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForLastName(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.LastName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<UsersSortTerm> messageTransformer,
            GetAllUsersQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }
    }
}

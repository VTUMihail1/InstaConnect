namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserValidationAssertions
{
    extension(TestValidationResult<UpdateCurrentUserCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForFirstName(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FirstName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForLastName(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.LastName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForName(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForEmail(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Email, messageTransformer, request);
        }
    }

    extension(TestValidationResult<DeleteUserCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            DeleteUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }
    }

    extension(TestValidationResult<DeleteCurrentUserCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetUserByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            GetUserByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetUserByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetCurrentUserByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetCurrentUserByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetUserDetailsByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            GetUserDetailsByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetUserDetailsByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetCurrentUserDetailsByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetCurrentUserDetailsByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddUserCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForFirstName(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FirstName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForLastName(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.LastName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForName(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForEmail(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Email, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPassword(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Password, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForConfirmPassword(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ConfirmPassword, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllUsersQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForName(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForFirstName(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FirstName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForLastName(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.LastName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(
            IIntMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(
            IEnumMessageTransformer<UsersSortTerm> messageTransformer,
            GetAllUsersQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }
}

using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
    extension(AddUserApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        AddUserApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, request));
        }
    }

    extension(UpdateCurrentUserApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        UpdateCurrentUserApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, request));
        }
    }

    extension(GetUserByIdApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        GetUserByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, request));
        }
    }


    extension(GetCurrentUserByIdApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        GetCurrentUserByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, request));
        }
    }

    extension(GetUserDetailsByIdApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        GetUserDetailsByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, request));
        }
    }


    extension(GetCurrentUserDetailsByIdApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        GetCurrentUserDetailsByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, request));
        }
    }

    extension(GetAllUsersApiResponse response)
    {
        public void ShouldSatisfy(
        ICollection<User> users,
        GetAllUsersApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(users, request));
        }

        public void ShouldSatisfy(
            ICollection<User> users,
            GetAllUsersApiRequest request,
            ISortEnumTermTransformer<User> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(users, request, termTransformer));
        }
    }

    extension(ActionResult<AddUserApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        AddUserApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, request));
        }
    }

    extension(ActionResult<UpdateCurrentUserApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        UpdateCurrentUserApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, request));
        }
    }

    extension(ActionResult<GetUserByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        GetUserByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, request));
        }
    }

    extension(ActionResult<GetCurrentUserByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        GetCurrentUserByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, request));
        }
    }

    extension(ActionResult<GetUserDetailsByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        GetUserDetailsByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, request));
        }
    }

    extension(ActionResult<GetCurrentUserDetailsByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        GetCurrentUserDetailsByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, request));
        }
    }

    extension(ActionResult<GetAllUsersApiResponse> response)
    {
        public void ShouldSatisfy(
        ICollection<User> users,
        GetAllUsersApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(users, request));
        }
    }

    extension(User user)
    {
        public void ShouldSatisfy(AddUserApiRequest request, IPasswordHasher passwordHasher)
        {
            user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
        }

        public void ShouldSatisfy(UpdateCurrentUserApiRequest request)
        {
            user.ShouldSatisfy(p => p.Matches(request));
        }
    }
}

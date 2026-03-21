using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserEquals
{
    extension(GetAllUsersQueryRequest query)
    {
        public bool Matches(GetAllUsersApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllUsersQueryRequest, UsersSortTerm, GetAllUsersApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllUsersApiRequest request)
        {
            return query.Name == request.Name &&
                   query.FirstName == request.FirstName &&
                   query.LastName == request.LastName;
        }
    }

    extension(GetUserByIdQueryRequest query)
    {
        public bool Matches(GetUserByIdApiRequest request)
        {
            return query.Id == request.Id &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(GetUserDetailsByIdQueryRequest query)
    {
        public bool Matches(GetUserDetailsByIdApiRequest request)
        {
            return query.Id == request.Id &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(GetCurrentUserByIdQueryRequest query)
    {
        public bool Matches(GetCurrentUserByIdApiRequest request)
        {
            return query.CurrentId == request.CurrentId &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(GetCurrentUserDetailsByIdQueryRequest query)
    {
        public bool Matches(GetCurrentUserDetailsByIdApiRequest request)
        {
            return query.CurrentId == request.CurrentId &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddUserCommandRequest command)
    {
        public bool Matches(AddUserApiRequest request)
        {
            return command.Email == request.Form.Email &&
                   command.Name == request.Form.Name &&
                   command.FirstName == request.Form.FirstName &&
                   command.LastName == request.Form.LastName &&
                   command.Password == request.Form.Password &&
                   command.ConfirmPassword == request.Form.ConfirmPassword &&
                   command.ProfileImage == request.Form.ProfileImage;
        }
    }

    extension(UpdateCurrentUserCommandRequest command)
    {
        public bool Matches(UpdateCurrentUserApiRequest request)
        {
            return command.Id == request.Id &&
                   command.Email == request.Form.Email &&
                   command.Name == request.Form.Name &&
                   command.FirstName == request.Form.FirstName &&
                   command.LastName == request.Form.LastName &&
                   command.ProfileImage == request.Form.ProfileImage;
        }
    }

    extension(DeleteUserCommandRequest command)
    {
        public bool Matches(DeleteUserApiRequest request)
        {
            return command.Id == request.Id;
        }
    }

    extension(DeleteCurrentUserCommandRequest command)
    {
        public bool Matches(DeleteCurrentUserApiRequest request)
        {
            return command.CurrentId == request.CurrentId;
        }
    }

    extension(AddUserApiResponse response)
    {
        public bool Matches(
        User user,
        AddUserApiRequest request)
        {
            return response.Id.Matches(user.Id);
        }
    }

    extension(UpdateCurrentUserApiResponse response)
    {
        public bool Matches(
        User user,
        UpdateCurrentUserApiRequest request)
        {
            return response.Id.Matches(user.Id);
        }
    }

    extension(GetUserByIdApiResponse response)
    {
        public bool Matches(User user, GetUserByIdApiRequest request)
        {
            return response.User.MatchesFull(user, request);
        }
    }


    extension(GetUserDetailsByIdApiResponse response)
    {
        public bool Matches(User user, GetUserDetailsByIdApiRequest request)
        {
            return response.User.MatchesFull(user, request);
        }
    }

    extension(GetCurrentUserByIdApiResponse response)
    {
        public bool Matches(User user, GetCurrentUserByIdApiRequest request)
        {
            return response.User.MatchesFull(user, request);
        }
    }


    extension(GetCurrentUserDetailsByIdApiResponse response)
    {
        public bool Matches(User user, GetCurrentUserDetailsByIdApiRequest request)
        {
            return response.User.MatchesFull(user, request);
        }
    }

    extension(GetAllUsersApiResponse response)
    {
        public bool Matches(
        ICollection<User> users,
        GetAllUsersApiRequest request)
        {
            return response.UserCollection.MatchesFull(
                       (response, user) => response.MatchesFull(user, request),
                       user => user.MatchesFilter(request),
                       users,
                       request);
        }

        public bool Matches(
            ICollection<User> users,
            GetAllUsersApiRequest request,
            ISortEnumTermTransformer<User> termTransformer)
        {
            return response.UserCollection.MatchesFull(
                       (response, user) => response.MatchesFull(user, request),
                       user => user.MatchesFilter(request),
                       users,
                       request,
                       termTransformer);
        }
    }

    extension(User user)
    {
        public bool Matches(AddUserApiRequest request, IPasswordHasher passwordHasher)
        {
            return user.FirstName == request.Form.FirstName &&
                   user.LastName == request.Form.LastName &&
                   user.Name.Matches(request.Form.Name) &&
                   user.Email.Matches(request.Form.Email) &&
                   passwordHasher.IsMatch(request.Form.Password, user.PasswordHash) &&
                   user.ProfileImage.Matches(request.Form.ProfileImage?.GetUrl());
        }

        public bool Matches(UpdateCurrentUserApiRequest request)
        {
            return user.Id.Matches(request.Id) &&
                   user.FirstName == request.Form.FirstName &&
                   user.LastName == request.Form.LastName &&
                   user.Name.Matches(request.Form.Name) &&
                   user.Email.Matches(request.Form.Email) &&
                   user.ProfileImage.Matches(request.Form.ProfileImage?.GetUrl());
        }

        public bool MatchesFilter(GetAllUsersApiRequest request)
        {

            return user.Name.Value.StartsWithOrdinalIgnoreCase(request.Name) &&
                   user.FirstName.StartsWithOrdinalIgnoreCase(request.FirstName) &&
                   user.LastName.StartsWithOrdinalIgnoreCase(request.LastName);
        }
    }

    extension(UserIdApiResponse response)
    {
        public bool Matches(UserId id)
        {
            return id.Matches(response.Id);
        }
    }

    extension(UserApiResponse? response)
    {
        public bool MatchesFull<TRequest>(User? user, TRequest request)
        where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   user != null &&
                   user.Id.Matches(response.Id) &&
                   user.FirstName == response.FirstName &&
                   user.LastName == response.LastName &&
                   user.Name.Matches(response.Name) &&
                   user.ProfileImage.Matches(response.ProfileImageUrl) &&
                   user.CreatedAtUtc == response.CreatedAtUtc &&
                   user.UpdatedAtUtc == response.UpdatedAtUtc;
        }
    }

    extension(UserDetailsApiResponse? response)
    {
        public bool MatchesFull<TRequest>(User? user, TRequest request)
        where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   user != null &&
                   user.Id.Matches(response.Id) &&
                   user.FirstName == response.FirstName &&
                   user.LastName == response.LastName &&
                   user.Name.Matches(response.Name) &&
                   user.Email.Matches(response.Email) &&
                   user.ProfileImage.Matches(response.ProfileImageUrl) &&
                   user.CreatedAtUtc == response.CreatedAtUtc &&
                   user.UpdatedAtUtc == response.UpdatedAtUtc;
        }
    }

    extension(UserCollectionApiResponse response)
    {
        public bool MatchesFull<TRequest>(
        Func<UserApiResponse, User, bool> matches,
        Func<User, bool> matchesFilter,
        ICollection<User> users,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(users.Count(matchesFilter), request) &&
                   response.Users.MatchesCollection(users,
                                                    response => new(response.Id),
                                                    user => user.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesFull<TRequest>(
            Func<UserApiResponse, User, bool> matches,
            Func<User, bool> matchesFilter,
            ICollection<User> users,
            TRequest request,
            ISortEnumTermTransformer<User> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(users.Count(matchesFilter), request) &&
                   response.Users.MatchesSortedCollection(users,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }
    }

    extension<TQueryRequest>(TQueryRequest query) where TQueryRequest : ICurrentUserableQueryRequest
    {
        public bool MatchesCurrentUserable<TApiRequest>(
        TApiRequest request)
        where TApiRequest : ICurrentUserableApiRequest
        {
            return query.CurrentId == request.CurrentId;
        }
    }
}

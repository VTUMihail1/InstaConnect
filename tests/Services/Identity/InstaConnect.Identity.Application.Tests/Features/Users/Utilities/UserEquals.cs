using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserEquals
{
    extension(GetAllUsersQuery query)
    {
        public bool Matches(GetAllUsersQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllUsersQuery, UsersSortTerm, UsersSortingQuery, GetAllUsersQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllUsersQuery, UsersPaginationQuery, GetAllUsersQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllUsersQueryRequest request)
        {
            return query.Filter.Name.Matches(request.Name) &&
                   query.Filter.FirstName == request.FirstName &&
                   query.Filter.LastName == request.LastName;
        }
    }

    extension(GetUserByIdQuery query)
    {
        public bool Matches(GetUserByIdQueryRequest request)
        {
            return query.Id.Matches(request.Id) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool Matches(GetCurrentUserByIdQueryRequest request)
        {
            return query.Id.Matches(request.CurrentId) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool Matches(GetUserDetailsByIdQueryRequest request)
        {
            return query.Id.Matches(request.Id) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool Matches(GetCurrentUserDetailsByIdQueryRequest request)
        {
            return query.Id.Matches(request.CurrentId) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddUserCommand command)
    {
        public bool Matches(AddUserCommandRequest request)
        {
            return command.Email.Matches(request.Email) &&
                   command.Name.Matches(request.Name) &&
                   command.FirstName == request.FirstName &&
                   command.LastName == request.LastName &&
                   command.Password == request.Password &&
                   command.ConfirmPassword == request.ConfirmPassword &&
                   command.ProfileImage == request.ProfileImage;
        }
    }

    extension(UpdateUserCommand command)
    {
        public bool Matches(UpdateCurrentUserCommandRequest request)
        {
            return command.Id.Matches(request.Id) &&
                   command.Email.Matches(request.Email) &&
                   command.Name.Matches(request.Name) &&
                   command.FirstName == request.FirstName &&
                   command.LastName == request.LastName &&
                   command.ProfileImage == request.ProfileImage;
        }
    }

    extension(DeleteUserCommand command)
    {
        public bool Matches(DeleteUserCommandRequest request)
        {
            return command.Id.Matches(request.Id);
        }

        public bool Matches(DeleteCurrentUserCommandRequest request)
        {
            return command.Id.Matches(request.CurrentId);
        }
    }

    extension(AddUserCommandResponse response)
    {
        public bool Matches(User user, AddUserCommandRequest request)
        {
            return response.Response.Matches(user.Id);
        }
    }

    extension(UpdateCurrentUserCommandResponse response)
    {
        public bool Matches(User user, UpdateCurrentUserCommandRequest request)
        {
            return response.Response.Matches(user.Id);
        }
    }

    extension(GetUserByIdQueryResponse response)
    {
        public bool Matches(User user, GetUserByIdQueryRequest request)
        {
            return response.Response.MatchesFull(user, request);
        }
    }

    extension(GetCurrentUserByIdQueryResponse response)
    {
        public bool Matches(User user, GetCurrentUserByIdQueryRequest request)
        {
            return response.Response.MatchesFull(user, request);
        }
    }

    extension(GetUserDetailsByIdQueryResponse response)
    {
        public bool Matches(User user, GetUserDetailsByIdQueryRequest request)
        {
            return response.Response.MatchesFull(user, request);
        }
    }

    extension(GetCurrentUserDetailsByIdQueryResponse response)
    {
        public bool Matches(User user, GetCurrentUserDetailsByIdQueryRequest request)
        {
            return response.Response.MatchesFull(user, request);
        }
    }

    extension(GetAllUsersQueryResponse response)
    {
        public bool Matches(
        ICollection<User> users,
        GetAllUsersQueryRequest request)
        {
            return response.Response.MatchesFull(
                       (response, user) => response.MatchesFull(user, request),
                       user => user.MatchesFilter(request),
                       users,
                       request);
        }

        public bool Matches(
            ICollection<User> users,
            GetAllUsersQueryRequest request,
            ISortEnumTermTransformer<User> termTransformer)
        {
            return response.Response.MatchesFull(
                       (response, user) => response.MatchesFull(user, request),
                       user => user.MatchesFilter(request),
                       users,
                       request,
                       termTransformer);
        }
    }

    extension(User user)
    {
        public bool Matches(AddUserCommandRequest request, IPasswordHasher passwordHasher)
        {
            return user.FirstName == request.FirstName &&
                   user.LastName == request.LastName &&
                   user.Name.Matches(request.Name) &&
                   user.Email.Matches(request.Email) &&
                   passwordHasher.IsMatch(request.Password, user.PasswordHash) &&
                   user.IsEmailNotConfirmed &&
                   user.ProfileImage.Matches(request.ProfileImage?.GetUrl());
        }

        public bool Matches(UpdateCurrentUserCommandRequest request)
        {
            return user.Id.Matches(request.Id) &&
                   user.FirstName == request.FirstName &&
                   user.LastName == request.LastName &&
                   user.Name.Matches(request.Name) &&
                   user.Email.Matches(request.Email) &&
                   (request.ProfileImage == null ||
                   user.ProfileImage.Matches(request.ProfileImage.GetUrl()));
        }

        public bool Matches(VerifyEmailConfirmationTokenCommandRequest request)
        {
            return user.IsEmailConfirmed;
        }

        public bool Matches(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
        {
            return passwordHasher.IsMatch(request.Password, user.PasswordHash);
        }

        public bool MatchesFilter(GetAllUsersQueryRequest request)
        {
            return user.Name.Value.StartsWithOrdinalIgnoreCase(request.Name) &&
                   user.FirstName.StartsWithOrdinalIgnoreCase(request.FirstName) &&
                   user.LastName.StartsWithOrdinalIgnoreCase(request.LastName);
        }
    }

    extension(UserIdCommandResponse response)
    {
        public bool Matches(UserId id)
        {
            return id.Matches(response.Id);
        }
    }

    extension(UserQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(User? user, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
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

    extension(UserDetailsQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(User? user, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
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

    extension(UserCollectionQueryResponse response)
    {
        public bool MatchesFull<TRequest>(
        Func<UserQueryResponse, User, bool> matches,
        Func<User, bool> matchesFilter,
        ICollection<User> users,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
            Func<UserQueryResponse, User, bool> matches,
            Func<User, bool> matchesFilter,
            ICollection<User> users,
            TRequest request,
            ISortEnumTermTransformer<User> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(users.Count(matchesFilter), request) &&
                   response.Users.MatchesSortedCollection(users,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }
    }

    extension<TQuery>(TQuery query) where TQuery : ICurrentUserableQuery
    {
        public bool MatchesCurrentUserable<TQueryRequest>(
        TQueryRequest request)
        where TQueryRequest : ICurrentUserableQueryRequest
        {
            return query.Current.Id.Matches(request.CurrentId);
        }
    }
}

using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
    extension(GetAllUserClaimsQuery query)
    {
        public bool Matches(GetAllUserClaimsQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllUserClaimsQuery, UserClaimsSortTerm, UserClaimsSortingQuery, GetAllUserClaimsQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllUserClaimsQuery, UserClaimsPaginationQuery, GetAllUserClaimsQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllUserClaimsQueryRequest request)
        {
            return query.Filter.Id.Matches(request.Id);
        }
    }

    extension(AddUserClaimCommand command)
    {
        public bool Matches(AddUserClaimCommandRequest request)
        {
            return command.Id.Matches(request.Id) &&
                   command.Claim == request.Claim;
        }
    }

    extension(DeleteUserClaimCommand command)
    {
        public bool Matches(DeleteUserClaimCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.Claim);
        }
    }

    extension(AddUserClaimCommandResponse response)
    {
        public bool Matches(UserClaim userClaim, AddUserClaimCommandRequest request)
        {
            return response.Response.Matches(userClaim.Id);
        }
    }

    extension(GetAllUserClaimsQueryResponse response)
    {
        public bool Matches(
            User user,
            ICollection<UserClaim> userClaims,
            GetAllUserClaimsQueryRequest request)
        {
            return response.Response.MatchesFull(
                       (response, userClaim) => response.MatchesWithoutUser(userClaim, request),
                       userClaim => userClaim.MatchesFilter(request),
                       user,
                       userClaims,
                       request);
        }

        public bool Matches(
            User user,
            ICollection<UserClaim> userClaims,
            GetAllUserClaimsQueryRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
        {
            return response.Response.MatchesFull(
                       (response, userClaim) => response.MatchesWithoutUser(userClaim, request),
                       userClaim => userClaim.MatchesFilter(request),
                       user,
                       userClaims,
                       request,
                       termTransformer);
        }
    }

    extension(UserClaim userClaim)
    {
        public bool Matches(AddUserClaimCommandRequest request)
        {
            return userClaim.Id.Matches(request.Id, request.Claim);
        }

        public bool MatchesFilter(GetAllUserClaimsQueryRequest request)
        {
            return userClaim.Id.Id.Matches(request.Id);
        }
    }

    extension(UserClaimIdCommandResponse response)
    {
        public bool Matches(UserClaimId id)
        {
            return id.Matches(response.Id, response.Claim);
        }
    }

    extension(UserClaimQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(UserClaim? userClaim, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   userClaim != null &&
                   userClaim.Id.Matches(response.Id, response.Claim) &&
                   response.User.MatchesFull(userClaim.User, request) &&
                   userClaim.CreatedAtUtc == response.CreatedAtUtc;
        }

        public bool MatchesWithoutUser<TRequest>(UserClaim? userClaim, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   userClaim != null &&
                   userClaim.Id.Matches(response.Id, response.Claim) &&
                   response.User == null &&
                   userClaim.CreatedAtUtc == response.CreatedAtUtc;
        }
    }

    extension(UserClaimCollectionQueryResponse response)
    {
        public bool MatchesFull<TRequest>(
        Func<UserClaimQueryResponse, UserClaim, bool> matches,
        Func<UserClaim, bool> matchesFilter,
        User user,
        ICollection<UserClaim> userClaims,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(userClaims.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user, request) &&
                   response.UserClaims.MatchesCollection(userClaims,
                                                    response => new(new(response.Id), response.Claim),
                                                    userClaim => userClaim.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesFull<TRequest>(
            Func<UserClaimQueryResponse, UserClaim, bool> matches,
            Func<UserClaim, bool> matchesFilter,
            User user,
            ICollection<UserClaim> userClaims,
            TRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(userClaims.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user, request) &&
                   response.UserClaims.MatchesSortedCollection(userClaims,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }

        public bool MatchesWithoutUser<TRequest>(
        Func<UserClaimQueryResponse, UserClaim, bool> matches,
        Func<UserClaim, bool> matchesFilter,
        ICollection<UserClaim> userClaims,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(userClaims.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.UserClaims.MatchesCollection(userClaims,
                                                    response => new(new(response.Id), response.Claim),
                                                    userClaim => userClaim.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesWithoutUser<TRequest>(
            Func<UserClaimQueryResponse, UserClaim, bool> matches,
            Func<UserClaim, bool> matchesFilter,
            ICollection<UserClaim> userClaims,
            TRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(userClaims.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.UserClaims.MatchesSortedCollection(userClaims,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }
    }
}

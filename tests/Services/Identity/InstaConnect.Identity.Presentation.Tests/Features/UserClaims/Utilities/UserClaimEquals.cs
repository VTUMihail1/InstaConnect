using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
    extension(GetAllUserClaimsQueryRequest query)
    {
        public bool Matches(GetAllUserClaimsApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllUserClaimsQueryRequest, UserClaimsSortTerm, GetAllUserClaimsApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllUserClaimsApiRequest request)
        {
            return query.Id == request.Id;
        }
    }

    extension(AddUserClaimCommandRequest command)
    {
        public bool Matches(AddUserClaimApiRequest request)
        {
            return command.Id == request.Id &&
                   command.Claim == request.Body.Claim;
        }
    }

    extension(DeleteUserClaimCommandRequest command)
    {
        public bool Matches(DeleteUserClaimApiRequest request)
        {
            return command.Id == request.Id &&
                   command.Claim == request.Claim;
        }
    }

    extension(AddUserClaimApiResponse response)
    {
        public bool Matches(UserClaim userClaim, AddUserClaimApiRequest request)
        {
            return response.Id.Matches(userClaim.Id);
        }
    }

    extension(GetAllUserClaimsApiResponse response)
    {
        public bool Matches(
            User user,
            ICollection<UserClaim> userClaims,
            GetAllUserClaimsApiRequest request)
        {
            return response.UserClaimCollection.MatchesFull(
                       (response, userClaim) => response.MatchesFull(userClaim, request),
                       userClaim => userClaim.MatchesFilter(request),
                       user,
                       userClaims,
                       request);
        }

        public bool Matches(
            User user,
            ICollection<UserClaim> userClaims,
            GetAllUserClaimsApiRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
        {
            return response.UserClaimCollection.MatchesFull(
                       (response, userClaim) => response.MatchesFull(userClaim, request),
                       userClaim => userClaim.MatchesFilter(request),
                       user,
                       userClaims,
                       request,
                       termTransformer);
        }
    }

    extension(UserClaim userClaim)
    {
        public bool Matches(AddUserClaimApiRequest request)
        {
            return userClaim.Id.Matches(request.Id, request.Body.Claim);
        }

        public bool MatchesFilter(GetAllUserClaimsApiRequest request)
        {
            return userClaim.Id.Id.Matches(request.Id);
        }
    }

    extension(UserClaimIdApiResponse response)
    {
        public bool Matches(UserClaimId id)
        {
            return id.Matches(response.Id, response.Claim);
        }
    }

    extension(UserClaimApiResponse? response)
    {
        public bool MatchesFull<TRequest>(UserClaim? userClaim, TRequest request)
        where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   userClaim != null &&
                   userClaim.Id.Matches(response.Id, response.Claim) &&
                   response.User.MatchesFull(userClaim.User, request) &&
                   userClaim.CreatedAtUtc == response.CreatedAtUtc;
        }

        public bool MatchesWithoutUser<TRequest>(UserClaim? userClaim, TRequest request)
        where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   userClaim != null &&
                   userClaim.Id.Matches(response.Id, response.Claim) &&
                   response.User == null &&
                   userClaim.CreatedAtUtc == response.CreatedAtUtc;
        }
    }

    extension(UserClaimCollectionApiResponse response)
    {
        public bool MatchesFull<TRequest>(
        Func<UserClaimApiResponse, UserClaim, bool> matches,
        Func<UserClaim, bool> matchesFilter,
        User user,
        ICollection<UserClaim> userClaims,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<UserClaimApiResponse, UserClaim, bool> matches,
            Func<UserClaim, bool> matchesFilter,
            User user,
            ICollection<UserClaim> userClaims,
            TRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
        Func<UserClaimApiResponse, UserClaim, bool> matches,
        Func<UserClaim, bool> matchesFilter,
        ICollection<UserClaim> userClaims,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<UserClaimApiResponse, UserClaim, bool> matches,
            Func<UserClaim, bool> matchesFilter,
            ICollection<UserClaim> userClaims,
            TRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

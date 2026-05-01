using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		internal UserClaimId ToIdResponse(
)
		{
			return userClaim.Id;
		}

		internal UserClaimResponse ToFullResponse()
		{
			return new(userClaim.Id,
					   userClaim.User?.ToFullResponse(),
					   userClaim.CreatedAtUtc);
		}

		internal UserClaimResponse ToResponseWithoutUser()
		{
			return new(userClaim.Id,
					   null,
					   userClaim.CreatedAtUtc);
		}

		public UserClaimId ToResponse(
			AddUserClaimCommandRequest request)
		{
			return userClaim.ToIdResponse();
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		internal UserClaimCollectionResponse ToFullResponse<TRequest>(
			 User user,
			 Func<UserClaim, TRequest, bool> filter,
			 Func<UserClaim, TRequest, UserClaimResponse> transform,
			 TRequest request)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = userClaims.Count(userClaim => filter(userClaim, request));

			return new(user.ToFullResponse(),
					   userClaims.Filter(userClaim => filter(userClaim, request), request, userClaim => transform(userClaim, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal UserClaimCollectionResponse ToResponseWithoutUser<TRequest>(
			 Func<UserClaim, TRequest, bool> filter,
			 Func<UserClaim, TRequest, UserClaimResponse> transform,
			 TRequest request)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = userClaims.Count(userClaim => filter(userClaim, request));

			return new(null,
					   userClaims.Filter(userClaim => filter(userClaim, request), request, userClaim => transform(userClaim, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public UserClaimCollectionResponse ToResponse(
			User user,
			GetAllUserClaimsQueryRequest request)
		{
			return userClaims.ToFullResponse(
				user,
				(userClaim, request) => userClaim.MatchesFilter(request),
				(userClaim, request) => userClaim.ToResponseWithoutUser(),
				request);
		}
	}
}

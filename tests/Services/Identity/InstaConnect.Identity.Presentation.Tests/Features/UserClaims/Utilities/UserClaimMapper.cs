using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		internal UserClaimIdCommandResponse ToIdResponse(
)
		{
			return new(userClaim.Id.Id.Id, userClaim.Id.Claim);
		}

		internal UserClaimQueryResponse ToFullResponse()
		{
			return new(userClaim.Id.Id.Id,
					   userClaim.Id.Claim,
					   userClaim.User?.ToFullResponse(),
					   userClaim.CreatedAtUtc);
		}

		internal UserClaimQueryResponse ToResponseWithoutUser()
		{
			return new(userClaim.Id.Id.Id,
					   userClaim.Id.Claim,
					   null,
					   userClaim.CreatedAtUtc);
		}

		public AddUserClaimCommandResponse ToResponse(
			AddUserClaimApiRequest request)
		{
			return new(userClaim.ToIdResponse());
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		internal UserClaimCollectionQueryResponse ToFullResponse<TRequest>(
			 User user,
			 Func<UserClaim, TRequest, bool> filter,
			 Func<UserClaim, TRequest, UserClaimQueryResponse> transform,
			 TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		internal UserClaimCollectionQueryResponse ToResponseWithoutUser<TRequest>(
			 Func<UserClaim, TRequest, bool> filter,
			 Func<UserClaim, TRequest, UserClaimQueryResponse> transform,
			 TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		public GetAllUserClaimsQueryResponse ToResponse(
			User user,
			GetAllUserClaimsApiRequest request)
		{
			return new(userClaims.ToFullResponse(
				user,
				(userClaim, request) => userClaim.MatchesFilter(request),
				(userClaim, request) => userClaim.ToResponseWithoutUser(),
				request));
		}
	}
}

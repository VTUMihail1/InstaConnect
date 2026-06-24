using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		internal UserClaimIdCommandResponse ToIdCommandResponse(
)
		{
			return new(userClaim.Id.Id.Id, userClaim.Id.Claim);
		}

		internal UserClaimQueryResponse ToFullQueryResponse()
		{
			return new(userClaim.Id.Id.Id,
					   userClaim.Id.Claim,
					   userClaim.User?.ToFullQueryResponse(),
					   userClaim.CreatedAtUtc);
		}

		internal UserClaimQueryResponse ToQueryResponseWithoutUser()
		{
			return new(userClaim.Id.Id.Id,
					   userClaim.Id.Claim,
					   null,
					   userClaim.CreatedAtUtc);
		}

		public AddUserClaimCommandResponse ToResponse(
			AddUserClaimApiRequest request)
		{
			return new(userClaim.ToIdCommandResponse());
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		internal UserClaimCollectionQueryResponse ToFullQueryResponse<TRequest>(
			 User user,
			 Func<UserClaim, TRequest, bool> filter,
			 Func<UserClaim, TRequest, UserClaimQueryResponse> transform,
			 TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = userClaims.Count(userClaim => filter(userClaim, request));

			return new(user.ToFullQueryResponse(),
					   userClaims.Filter(userClaim => filter(userClaim, request), request, userClaim => transform(userClaim, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal UserClaimCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
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
			return new(userClaims.ToFullQueryResponse(
				user,
				(userClaim, request) => userClaim.MatchesFilter(request),
				(userClaim, request) => userClaim.ToQueryResponseWithoutUser(),
				request));
		}
	}
}

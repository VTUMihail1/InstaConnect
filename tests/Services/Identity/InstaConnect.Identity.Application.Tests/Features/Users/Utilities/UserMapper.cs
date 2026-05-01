using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		internal UserId ToIdResponse(
)
		{
			return user.Id;
		}

		internal UserResponse ToFullResponse()
		{
			return new(user.Id,
					   user.FirstName,
					   user.LastName,
					   user.Email,
					   user.Name,
					   user.ProfileImage,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}

		public UserId ToResponse(
			AddUserCommandRequest request)
		{
			return user.ToIdResponse();
		}

		public UserId ToResponse(
			UpdateCurrentUserCommandRequest request)
		{
			return user.ToIdResponse();
		}

		public UserResponse ToResponse(
			GetUserByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}

		public UserResponse ToResponse(
			GetCurrentUserByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}

		public UserResponse ToResponse(
			GetUserDetailsByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}

		public UserResponse ToResponse(
			GetCurrentUserDetailsByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}
	}

	extension(ICollection<User> users)
	{
		internal UserCollectionResponse ToFullResponse<TRequest>(
		Func<User, TRequest, bool> filter,
		Func<User, TRequest, UserResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = users.Count(user => filter(user, request));

			return new(users.Filter(user => filter(user, request), request, user => transform(user, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public UserCollectionResponse ToResponse(
			GetAllUsersQueryRequest request)
		{
			return users.ToFullResponse(
				(user, request) => user.MatchesFilter(request),
				(user, request) => user.ToFullResponse(),
				request);
		}
	}
}

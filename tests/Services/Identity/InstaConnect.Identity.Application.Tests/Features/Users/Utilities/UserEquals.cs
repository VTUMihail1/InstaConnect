using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserAddedEventRequest r)
	{
		public bool Matches(AddUserCommandRequest request, User entity)
		{
			return entity.Id.Matches(r.User.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(r.User.Name) &&
				   request.Email.EqualsOrdinalIgnoreCase(r.User.Email) &&
				   request.FirstName == r.User.FirstName &&
				   request.LastName == r.User.LastName &&
				   request.ProfileImage?.GetUrl() == r.User.ProfileImageUrl &&
				   entity.CreatedAtUtc == r.User.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.User.UpdatedAtUtc;
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, User entity)
		{
			return request.Id.EqualsOrdinalIgnoreCase(r.User.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(r.User.Name) &&
				   request.Email.EqualsOrdinalIgnoreCase(r.User.Email) &&
				   request.FirstName == r.User.FirstName &&
				   request.LastName == r.User.LastName &&
				   (request.ProfileImage == null ||
				   request.ProfileImage.GetUrl() == r.User.ProfileImageUrl) &&
				   entity.CreatedAtUtc == r.User.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.User.UpdatedAtUtc;
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool Matches(DeleteUserCommandRequest request, User entity)
		{
			return request.Id.EqualsOrdinalIgnoreCase(r.User.Id) &&
				   entity.Name.Matches(r.User.Name) &&
				   entity.Email.Matches(r.User.Email) &&
				   entity.FirstName == r.User.FirstName &&
				   entity.LastName == r.User.LastName &&
				   entity.ProfileImage.Matches(r.User.ProfileImageUrl) &&
				   entity.CreatedAtUtc == r.User.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.User.UpdatedAtUtc;
		}

		public bool Matches(DeleteCurrentUserCommandRequest request, User entity)
		{
			return request.CurrentId.EqualsOrdinalIgnoreCase(r.User.Id) &&
				   entity.Name.Matches(r.User.Name) &&
				   entity.Email.Matches(r.User.Email) &&
				   entity.FirstName == r.User.FirstName &&
				   entity.LastName == r.User.LastName &&
				   entity.ProfileImage.Matches(r.User.ProfileImageUrl) &&
				   entity.CreatedAtUtc == r.User.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.User.UpdatedAtUtc;
		}
	}

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
		public bool Matches(AddUserCommandRequest request, User user)
		{
			return response.Response.Matches(user.Id);
		}
	}

	extension(UpdateCurrentUserCommandResponse response)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, User user)
		{
			return response.Response.Matches(user.Id);
		}
	}

	extension(GetUserByIdQueryResponse response)
	{
		public bool Matches(GetUserByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}

	extension(GetCurrentUserByIdQueryResponse response)
	{
		public bool Matches(GetCurrentUserByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}

	extension(GetUserDetailsByIdQueryResponse response)
	{
		public bool Matches(GetUserDetailsByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(request, user);
		}
	}

	extension(GetCurrentUserDetailsByIdQueryResponse response)
	{
		public bool Matches(GetCurrentUserDetailsByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(request, user);
		}
	}

	extension(GetAllUsersQueryResponse response)
	{
		public bool Matches(
		GetAllUsersQueryRequest request,
		ICollection<User> users)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, user) => response.MatchesFull(user),
					   user => user.MatchesFilter(request),
					   users);
		}

		public bool Matches(
			GetAllUsersQueryRequest request,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, user) => response.MatchesFull(user),
					   user => user.MatchesFilter(request),
					   users,
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

		public bool MatchesFilter(GetAllUsersQueryRequest request)
		{
			return user.Name.Value.StartsWithOrdinalIgnoreCase(request.Name) &&
				   user.FirstName.StartsWithOrdinalIgnoreCase(request.FirstName) &&
				   user.LastName.StartsWithOrdinalIgnoreCase(request.LastName);
		}
	}

	extension(User? user)
	{
		public bool Matches(AddUserCommandRequest request, UserEventRequest r)
		{
			return user != null &&
				   user.Id.Matches(r.Id) &&
				   request.Name == r.Name &&
				   request.Email == r.Email &&
				   request.FirstName == r.FirstName &&
				   request.LastName == r.LastName &&
				   request.ProfileImage?.GetUrl() == r.ProfileImageUrl &&
				   user.CreatedAtUtc == r.CreatedAtUtc &&
				   user.UpdatedAtUtc == r.UpdatedAtUtc;
		}

		public bool Matches(UpdateCurrentUserCommandRequest request, UserEventRequest r)
		{
			return user != null &&
				   request.Id == r.Id &&
				   request.Name == r.Name &&
				   request.Email == r.Email &&
				   request.FirstName == r.FirstName &&
				   request.LastName == r.LastName &&
				   request.ProfileImage?.GetUrl() == r.ProfileImageUrl &&
				   user.CreatedAtUtc == r.CreatedAtUtc &&
				   user.UpdatedAtUtc == r.UpdatedAtUtc;
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
		public bool MatchesFull(User? user)
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
		public bool MatchesFull<TRequest>(TRequest request, User? user)
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
		TRequest request,
		Func<UserQueryResponse, User, bool> matches,
		Func<User, bool> matchesFilter,
		ICollection<User> users)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, users.Count(matchesFilter)) &&
				   response.Users.MatchesCollection(request,
													users,
													response => new(response.Id),
													user => user.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesFull<TRequest>(
			TRequest request,
			Func<UserQueryResponse, User, bool> matches,
			Func<User, bool> matchesFilter,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, users.Count(matchesFilter)) &&
				   response.Users.MatchesSortedCollection(request,
														  users,
														  matches,
														  termTransformer,
														  matchesFilter);
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public bool Matches(AddUserCommandRequest request)
		{
			return emailConfirmationToken.User!.Name.Matches(request.Name);
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddUserCommandRequest request, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(r.EmailConfirmationToken.Id, r.EmailConfirmationToken.Value) &&
				   entity.User.Matches(request, r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool Matches(AddUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(request, e));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(request.Id, r.EmailConfirmationToken.Value) &&
				   entity.User.Matches(request, r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(request, e));
		}
	}

	extension(ICollection<EmailConfirmationToken> entities)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request)
		{
			return entities.All(entity => entity.Id.Id.Matches(request.Id));
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

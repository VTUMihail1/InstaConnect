using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserId response)
	{
		public bool Matches(User user, AddUserCommand command)
		{
			return response.Matches(user.Id);
		}

		public bool Matches(User user, UpdateUserCommand command)
		{
			return response.Matches(user.Id);
		}
	}

	extension(User user)
	{
		public bool Matches(AddUserCommand command)
		{
			return user.Name.Matches(command.Name) &&
				   user.Email.Matches(command.Email) &&
				   user.FirstName == command.FirstName &&
				   user.LastName == command.LastName &&
				   user.ProfileImage.Matches(command.ProfileImage?.GetUrl());
		}

		public bool Matches(AddUserCommand command, UserEventRequest request)
		{
			return user.Id.Matches(request.Id) &&
				   command.Name.Matches(request.Name) &&
				   command.Email.Matches(request.Email) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.ProfileImage?.GetUrl() == request.ProfileImageUrl &&
				   user.CreatedAtUtc == request.CreatedAtUtc &&
				   user.UpdatedAtUtc == request.UpdatedAtUtc;
		}

		public bool Matches(UpdateUserCommand command)
		{
			return user.Id.Matches(command.Id) &&
				   user.Name.Matches(command.Name) &&
				   user.Email.Matches(command.Email) &&
				   user.FirstName == command.FirstName &&
				   user.LastName == command.LastName &&
				   (command.ProfileImage == null ||
				   user.ProfileImage.Matches(command.ProfileImage.GetUrl()));
		}

		public bool Matches(UpdateUserCommand command, UserEventRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.Name.Matches(request.Name) &&
				   command.Email.Matches(request.Email) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.ProfileImage?.GetUrl() == request.ProfileImageUrl &&
				   user.CreatedAtUtc == request.CreatedAtUtc &&
				   user.UpdatedAtUtc == request.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserCommand command)
		{
			return user.Id.Matches(command.Id);
		}

		public bool MatchesFilter(GetAllUsersQuery query)
		{
			return user.Name.Value.StartsWithOrdinalIgnoreCase(query.Filter.Name.Value) &&
				   user.FirstName.StartsWithOrdinalIgnoreCase(query.Filter.FirstName) &&
				   user.LastName.StartsWithOrdinalIgnoreCase(query.Filter.LastName);
		}
	}

	extension(UserResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.Email.Matches(response.Email) &&
				   user.ProfileImage.Matches(response.ProfileImage) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}

		public bool Matches(User user, GetUserByIdQuery query)
		{
			return response.MatchesFull(user);
		}
	}

	extension(UserCollectionResponse response)
	{
		public bool Matches(
			ICollection<User> users,
			GetAllUsersQuery query)
		{
			return response.MatchesCollectionResponse(users.Count(user => user.MatchesFilter(query)), query.Pagination) &&
				   response.Users.MatchesCollection(users,
													response => response.Id,
													user => user.Id,
													(response, user) => response.MatchesFull(user),
													query.Pagination,
													user => user.MatchesFilter(query));
		}

		public bool Matches(
			ICollection<User> users,
			GetAllUsersQuery query,
			ISortEnumTermTransformer<User> termTransformer)
		{
			return response.MatchesCollectionResponse(users.Count(user => user.MatchesFilter(query)), query.Pagination) &&
				   response.Users.MatchesSortedCollection(users,
														  (response, user) => response.MatchesFull(user),
														  termTransformer,
														  query.Pagination,
														  user => user.MatchesFilter(query));
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddUserCommand command, User entity)
		{
			return entity.Id.Matches(request.Id) &&
				   command.Name.Matches(request.Name) &&
				   command.Email.Matches(request.Email) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   entity.ProfileImage.Matches(command.ProfileImage?.GetUrl()) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(UserAddedEventRequest request)
	{
		public bool Matches(AddUserCommand command, User entity)
		{
			return entity.Id.Matches(request.User.Id) &&
				   command.Name.Matches(request.User.Name) &&
				   command.Email.Matches(request.User.Email) &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   command.ProfileImage?.GetUrl() == request.User.ProfileImageUrl &&
				   entity.CreatedAtUtc == request.User.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.User.UpdatedAtUtc;
		}
	}

	extension(UserUpdatedEventRequest request)
	{
		public bool Matches(UpdateUserCommand command, User entity)
		{
			return command.Id.Matches(request.User.Id) &&
				   command.Name.Matches(request.User.Name) &&
				   command.Email.Matches(request.User.Email) &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   (command.ProfileImage == null ||
				   command.ProfileImage.GetUrl() == request.User.ProfileImageUrl) &&
				   entity.CreatedAtUtc == request.User.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.User.UpdatedAtUtc;
		}
	}

	extension(UserDeletedEventRequest request)
	{
		public bool Matches(DeleteUserCommand command, User entity)
		{
			return command.Id.Matches(request.User.Id) &&
				   entity.Name.Matches(request.User.Name) &&
				   entity.Email.Matches(request.User.Email) &&
				   entity.FirstName == request.User.FirstName &&
				   entity.LastName == request.User.LastName &&
				   entity.ProfileImage.Matches(request.User.ProfileImageUrl) &&
				   entity.CreatedAtUtc == request.User.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.User.UpdatedAtUtc;
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public bool Matches(AddUserCommand command, User user)
		{
			return emailConfirmationToken.Id.Id.Matches(user.Id);
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public bool Matches(UpdateUserCommand command, User user)
		{
			return user.EmailConfirmationTokens.MatchesCollection(emailConfirmationTokens,
											  e => e.Id,
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(e));
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest request)
	{
		public bool Matches(AddUserCommand command, EmailConfirmationToken entity)
		{
			return entity.Id.Id.Matches(request.EmailConfirmationToken.Id) &&
				   entity.User != null && entity.User.Matches(command, request.EmailConfirmationToken.User);
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest request)
	{
		public bool Matches(UpdateUserCommand command, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(request.EmailConfirmationToken.Id, request.EmailConfirmationToken.Value) &&
				   entity.User != null && entity.User.Matches(request.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == request.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == request.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> requests)
	{
		public bool Matches(UpdateUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return requests.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(command, e));
		}
	}
}

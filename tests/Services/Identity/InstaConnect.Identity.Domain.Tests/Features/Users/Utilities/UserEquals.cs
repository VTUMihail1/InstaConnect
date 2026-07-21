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
		public bool Matches(AddUserCommand command, User user)
		{
			return response.Matches(user.Id);
		}

		public bool Matches(UpdateUserCommand command, User user)
		{
			return response.Matches(command.Id);
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

	extension(UserInclude p)
	{
		public bool Matches(UpdateUserCommand command, UserInclude include)
		{
			return p.Matches(include);
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

		public bool Matches(GetUserByIdQuery query, User user)
		{
			return response.MatchesFull(user);
		}
	}

	extension(UserCollectionResponse response)
	{
		public bool Matches(
			GetAllUsersQuery query,
			ICollection<User> users)
		{
			return response.MatchesCollectionResponse(query.Pagination, users.Count(user => user.MatchesFilter(query))) &&
				   response.Users.MatchesCollection(query.Pagination,
													users,
													response => response.Id,
													user => user.Id,
													(response, user) => response.MatchesFull(user),
													user => user.MatchesFilter(query));
		}

		public bool Matches(
			GetAllUsersQuery query,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			return response.MatchesCollectionResponse(query.Pagination, users.Count(user => user.MatchesFilter(query))) &&
				   response.Users.MatchesSortedCollection(query.Pagination,
														  users,
														  (response, user) => response.MatchesFull(user),
														  termTransformer,
														  user => user.MatchesFilter(query));
		}
	}

	extension(User? user)
	{
		public bool Matches(AddUserCommand command, UserEventRequest request)
		{
			return user != null &&
				   user.Id.Matches(request.Id) &&
				   command.Name.Matches(request.Name) &&
				   command.Email.Matches(request.Email) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.ProfileImage?.GetUrl() == request.ProfileImageUrl &&
				   user.CreatedAtUtc == request.CreatedAtUtc &&
				   user.UpdatedAtUtc == request.UpdatedAtUtc;
		}

		public bool Matches(UpdateUserCommand command, UserEventRequest request)
		{
			return user != null &&
				   command.Id.Matches(request.Id) &&
				   command.Name.Matches(request.Name) &&
				   command.Email.Matches(request.Email) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.ProfileImage?.GetUrl() == request.ProfileImageUrl &&
				   user.CreatedAtUtc == request.CreatedAtUtc &&
				   user.UpdatedAtUtc == request.UpdatedAtUtc;
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
		public bool Matches(AddUserCommand command)
		{
			return emailConfirmationToken.User!.Name.Matches(command.Name);
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddUserCommand command, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(r.EmailConfirmationToken.Id, r.EmailConfirmationToken.Value) &&
				   entity.User.Matches(command, r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool Matches(AddUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(command, e));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(UpdateUserCommand command, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(command.Id.Id, r.EmailConfirmationToken.Value) &&
				   entity.User.Matches(command, r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool Matches(UpdateUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(command, e));
		}
	}

	extension(ICollection<EmailConfirmationToken> entities)
	{
		public bool Matches(UpdateUserCommand command)
		{
			return entities.All(entity => entity.Id.Id.Matches(command.Id));
		}
	}
}

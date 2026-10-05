using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserCollection collection)
	{
		public void SetupAggregateFluent(
			UserId id,
			IUserFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			UserId id,
			CurrentUserQuery currentUserQuery,
			IUserFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			Name name,
			IUserFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			Email email,
			IUserFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IUserFluent fluent)
	{
		public void SetupAnyAsync(
			UserId id,
			User? user,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(user != null);
		}

		public void SetupAnyAsync(
			Name name,
			User? user,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(user != null);
		}

		public void SetupAnyAsync(
			Email email,
			User? user,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(user != null);
		}

		public void SetupApplyIncludes(
			UserId id,
			UserInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			Name name,
			UserInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			Email email,
			UserInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(UserId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(Name name)
		{
			fluent.Match(name).ReturnsResponse(fluent);
		}

		public void SetupMatch(Email email)
		{
			fluent.Match(email).ReturnsResponse(fluent);
		}

		public void SetupProjectToFullResponse(
			UserId id,
			CurrentUserQuery currentUserQuery,
			IUserResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			UserId id,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(user);
		}

		public void SetupFirstOrDefaultAsync(
			Name name,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(user);
		}

		public void SetupFirstOrDefaultAsync(
			Email email,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(user);
		}
	}

	extension(IUserResponseFluent fluent)
	{
		public void SetupFirstOrDefaultAsync(
			UserId id,
			CurrentUserQuery currentUserQuery,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(user.ToResponse(id, currentUserQuery));
		}
	}
}

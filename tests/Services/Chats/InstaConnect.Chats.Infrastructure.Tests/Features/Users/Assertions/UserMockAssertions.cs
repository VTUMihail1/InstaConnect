using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(UserId id)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(Name name)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(Email email)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(user, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(user, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(user, cancellationToken);
		}
	}

	extension(IUserFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(UserId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(Name name)
		{
			fluent.ShouldHaveReceivedOne().Match(name);
		}

		public void ShouldHaveReceivedOneMatch(Email email)
		{
			fluent.ShouldHaveReceivedOne().Match(email);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			UserId id,
			UserInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			Name name,
			UserInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			Email email,
			UserInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().AnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().AnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().AnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IUserResponseFluent fluent)
	{
		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			UserId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
		UserAddedEventRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddUserCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsUpdateUserCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeleteUserCommandRequest(), cancellationToken);
		}
	}
}

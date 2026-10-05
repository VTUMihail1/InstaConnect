using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IChatCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(ChatId id)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ChatsFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(chat, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(chat, cancellationToken);
		}
	}

	extension(IChatFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(ChatsFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(ChatId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatId id,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatsFilterQuery filterQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutParticipantOne(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutParticipantOne(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().AnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			ChatsFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().GetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IChatResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneApplySorting(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplyPagination(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().ToListAsync(cancellationToken);
		}
	}
}

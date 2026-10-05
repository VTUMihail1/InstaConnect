using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IChatMessageCollection collection)
	{
		public void SetupAggregateFluent(
			ChatMessageId id,
			IChatMessageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			IChatMessageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IChatMessageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			ChatMessagesFilterQuery filterQuery,
			IChatMessageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IChatMessageFluent fluent)
	{
		public void SetupGetCountAsync(
			ChatMessagesFilterQuery filterQuery,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(chatMessages.ToTotalCountResponse(filterQuery));
		}

		public void SetupAnyAsync(
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(true);
		}

		public void SetupApplyIncludes(
			ChatMessageId id,
			ChatMessageInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			ChatMessageInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			ChatMessagesFilterQuery filterQuery,
			ChatMessageInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatMessageInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(ChatMessageId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ChatMessagesFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupProjectToFullResponse(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			IChatMessageResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutChat(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IChatMessageResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutChat(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			ChatMessageId id,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(chatMessage);
		}
	}

	extension(IChatMessageResponseFluent fluent)
	{
		public void SetupApplySorting(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(chatMessages.ToResponse(filterQuery, paginationQuery));
		}

		public void SetupFirstOrDefaultAsync(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(chatMessage.ToFullResponse());
		}
	}
}

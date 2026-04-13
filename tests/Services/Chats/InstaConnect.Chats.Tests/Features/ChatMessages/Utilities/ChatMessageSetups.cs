using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
    extension(IServiceProvider serviceProvider)
    {
        public IChatMessageCommandRepository GetChatMessageCommandRepository()
        {
            return serviceProvider.GetRequiredService<IChatMessageCommandRepository>();
        }

        public IChatMessageIncludeBuilderFactory GetChatMessageIncludeBuilderFactory()
        {
            return serviceProvider.GetRequiredService<IChatMessageIncludeBuilderFactory>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IChatMessageCommandRepository GetChatMessageCommandRepository()
        {
            return serviceScope.ServiceProvider.GetChatMessageCommandRepository();
        }

        public IChatMessageIncludeBuilderFactory GetChatMessageIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetChatMessageIncludeBuilderFactory();
        }

        public async Task<ChatMessage?> GetChatMessageByIdAsync(
            ChatMessageId id,
            CancellationToken cancellationToken)
        {
            var include = serviceScope.GetChatIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();
            var messageInclude = serviceScope.GetChatMessageIncludeBuilderFactory().Create().WithSender().WithChat(include).Build();

            return await serviceScope.GetChatMessageCommandRepository().GetByIdAsync(id, messageInclude, cancellationToken);
        }

        public async Task AddChatMessageAsync(
            ChatMessage chatMessage,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetChatMessageCommandRepository().AddAsync(chatMessage, cancellationToken);
        }

        public async Task AddChatMessageRangeAsync(
            IEnumerable<ChatMessage> chatMessages,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetChatMessageCommandRepository().AddRangeAsync(chatMessages, cancellationToken);
        }

        public async Task UpdateChatMessageAsync(
            ChatMessage chatMessage,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetChatMessageCommandRepository().UpdateAsync(chatMessage, cancellationToken);
        }

        public async Task DeleteChatMessageAsync(
            ChatMessage chatMessage,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetChatMessageCommandRepository().DeleteAsync(chatMessage, cancellationToken);
        }
    }
}

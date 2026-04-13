using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
    extension(IServiceProvider serviceProvider)
    {
        public IChatCommandRepository GetChatCommandRepository()
        {
            return serviceProvider.GetRequiredService<IChatCommandRepository>();
        }

        public IChatIncludeBuilderFactory GetChatIncludeBuilderFactory()
        {
            return serviceProvider.GetRequiredService<IChatIncludeBuilderFactory>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IChatCommandRepository GetChatCommandRepository()
        {
            return serviceScope.ServiceProvider.GetChatCommandRepository();
        }

        public IChatIncludeBuilderFactory GetChatIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetChatIncludeBuilderFactory();
        }

        public async Task<Chat?> GetChatByIdAsync(
            ChatId id,
            CancellationToken cancellationToken)
        {
            var include = serviceScope.GetChatIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();

            return await serviceScope.GetChatCommandRepository().GetByIdAsync(id, include, cancellationToken);
        }

        public async Task AddChatAsync(
            Chat chat,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetChatCommandRepository().AddAsync(chat, cancellationToken);
        }

        public async Task AddChatRangeAsync(
            IEnumerable<Chat> chats,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetChatCommandRepository().AddRangeAsync(chats, cancellationToken);
        }

        public async Task DeleteChatAsync(
            Chat chat,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetChatCommandRepository().DeleteAsync(chat, cancellationToken);
        }
    }
}

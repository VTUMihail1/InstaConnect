using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatCommandRepository GetCommandRepository()
		{
			return serviceProvider.GetRequiredService<IChatCommandRepository>();
		}

		public IChatIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IChatIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatCommandRepository GetCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCommandRepository();
		}

		public IChatIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetIncludeBuilderFactory();
		}

		public async Task<Chat?> GetByIdAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();

			return (await serviceScope.GetCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetParticipantOne().SetParticipantTwo();
		}

		public async Task AddAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().AddAsync(chat, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().AddRangeAsync(chats, cancellationToken);
		}

		public async Task DeleteAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().DeleteAsync(chat, cancellationToken);
		}
	}
}

using InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetById;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
public interface IChatMessageService
{
    public Task<ChatMessageCollection> GetAllAsync(GetAllChatMessagesQuery query, CancellationToken cancellationToken);

    public Task<ChatMessage> GetByIdAsync(GetChatMessageByIdQuery query, CancellationToken cancellationToken);

    public Task<ChatMessage> AddAsync(AddChatMessageCommand command, CancellationToken cancellationToken);

    public Task<ChatMessage> UpdateAsync(UpdateChatMessageCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteChatMessageCommand command, CancellationToken cancellationToken);
}

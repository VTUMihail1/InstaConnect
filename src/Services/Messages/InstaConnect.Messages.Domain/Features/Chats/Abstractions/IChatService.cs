using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;
public interface IChatService
{
    public Task<ChatCollection> GetAllByParticipantAsync(GetAllChatsByParticipantQuery query, CancellationToken cancellationToken);

    public Task<Chat> GetByIdAsync(GetChatByIdQuery query, CancellationToken cancellationToken);

    public Task<Chat> AddAsync(AddChatCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteChatCommand command, CancellationToken cancellationToken);
}

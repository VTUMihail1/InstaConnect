using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

public record GetAllChatMessagesTotalCountQuerySpecification(
    string Sql,
    GetAllChatMessagesTotalCountQueryParameters Parameters);

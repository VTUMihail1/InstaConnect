using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;

public record GetMessageByIdQuery(string Id, string CurrentUserId) : IQuery<MessageQueryViewModel>;

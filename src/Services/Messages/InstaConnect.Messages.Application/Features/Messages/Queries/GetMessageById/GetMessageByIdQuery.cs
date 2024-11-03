using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;

public record GetMessageByIdQuery(string Id, string CurrentUserId) : IQuery<MessageQueryViewModel>;

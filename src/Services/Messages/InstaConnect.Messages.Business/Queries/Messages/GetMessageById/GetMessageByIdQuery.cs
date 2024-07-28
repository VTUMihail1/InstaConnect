using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Queries.Messages.GetMessageById;

public record GetMessageByIdQuery(string Id, string CurrentUserId) : IQuery<MessageQueryViewModel>;

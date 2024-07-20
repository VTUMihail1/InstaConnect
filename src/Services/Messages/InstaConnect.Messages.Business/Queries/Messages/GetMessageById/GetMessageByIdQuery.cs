using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Queries.Messages.GetMessageById;

public class GetMessageByIdQuery : IQuery<MessageReadViewModel>
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}

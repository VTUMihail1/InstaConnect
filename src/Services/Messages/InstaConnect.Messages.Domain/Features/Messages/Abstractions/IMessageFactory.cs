using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;

namespace InstaConnect.Messages.Domain.Features.Messages.Abstractions;
public interface IMessageFactory
{
    public Message Get(string senderId, string receiverId, string content);
}

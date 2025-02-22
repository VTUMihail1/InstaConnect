using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;

namespace InstaConnect.Messages.Domain.Features.Messages.Abstractions;
public interface IMessageService
{
    public void Update(Message message, string content);
}

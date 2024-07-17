using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Read.Data.Abstractions;

public interface IMessageRepository : IBaseReadRepository<Message>
{
}

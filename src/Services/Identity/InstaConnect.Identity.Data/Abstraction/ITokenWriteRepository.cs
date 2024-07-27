using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Identity.Data.Abstraction;

public interface ITokenWriteRepository : IBaseWriteRepository<Token>
{
    Task<Token?> GetByValueAsync(string value, CancellationToken cancellationToken);
}

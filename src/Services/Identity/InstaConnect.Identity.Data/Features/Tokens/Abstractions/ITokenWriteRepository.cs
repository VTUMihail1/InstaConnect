using InstaConnect.Identity.Data.Features.Tokens.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Data.Features.Tokens.Abstractions;

public interface ITokenWriteRepository : IBaseWriteRepository<Token>
{
    Task<Token?> GetByValueAsync(string value, CancellationToken cancellationToken);
}

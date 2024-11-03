using InstaConnect.Messages.Data.Features.Users.Models.Entities;

namespace InstaConnect.Messages.Data.Features.Users.Abstract;
public interface IUserWriteRepository
{
    void Add(User user);
    void Delete(User user);
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(User user);
}

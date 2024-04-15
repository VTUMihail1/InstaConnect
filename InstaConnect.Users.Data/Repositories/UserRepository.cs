using InstaConnect.Shared;
using InstaConnect.Shared.Repositories;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Users.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UsersContext _usersContext;

        public UserRepository(UsersContext usersContext) : base(usersContext)
        {
            _usersContext = usersContext;
        }

        public virtual async Task<User?> GetByEmailAsync(string email)
        {
            var entity = 
                await IncludeProperties(
                _usersContext.Users)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            return entity;
        }

        public virtual async Task<User?> GetByNameAsync(string name)
        {
            var entity =
                await IncludeProperties(
                _usersContext.Users)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == name);

            return entity;
        }
    }
}

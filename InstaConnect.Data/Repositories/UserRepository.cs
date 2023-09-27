using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public UserRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async override Task<ICollection<User>> GetAllAsync(Expression<Func<User, bool>> expression)
        {
            var users = await _instaConnectContext.Users
                .Where(expression)
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .Include(u => u.Senders)
                .Include(u => u.Receivers)
                .Include(u => u.Posts)
                .Include(p => p.PostComments)
                .Include(u => u.PostLikes)
                .Include(u => u.CommentLikes)
                .ToListAsync();

            return users;
        }

        public async override Task<User> FindEntityAsync(Expression<Func<User, bool>> expression)
        {
            var user = await _instaConnectContext.Users
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .Include(u => u.Senders)
                .Include(u => u.Receivers)
                .Include(u => u.Posts)
                .Include(p => p.PostComments)
                .Include(u => u.PostLikes)
                .Include(u => u.CommentLikes)
                .FirstOrDefaultAsync(expression);

            return user;
        }
    }
}

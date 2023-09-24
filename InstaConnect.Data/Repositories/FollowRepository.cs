using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class FollowRepository : Repository<Follow>, IFollowRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public FollowRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async Task<ICollection<Follow>> GetAllIncludedAsync()
        {
            var followers = await _instaConnectContext.Followers
                .Include(f => f.Follower)
                .Include(f => f.Following)
                .ToListAsync();

            return followers;
        }

        public async Task<ICollection<Follow>> GetAllFilteredIncludedAsync(Expression<Func<Follow, bool>> expression)
        {
            var followers = await _instaConnectContext.Followers
                .Where(expression)
                .Include(f => f.Follower)
                .Include(f => f.Following)
                .ToListAsync();

            return followers;
        }

        public async Task<Follow> FindIncludedAsync(Expression<Func<Follow, bool>> expression)
        {
            var followers = await _instaConnectContext.Followers
                .Include(f => f.Follower)
                .Include(f => f.Following)
                .FirstOrDefaultAsync(expression);

            return followers;
        }
    }
}

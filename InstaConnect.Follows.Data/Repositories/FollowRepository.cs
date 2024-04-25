using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Follows.Data.Repositories
{
    public class FollowRepository : BaseRepository<Follow>, IFollowRepository
    {
        private readonly FollowsContext _followsContext;

        public FollowRepository(FollowsContext followsContext) : base(followsContext)
        {
            _followsContext = followsContext;
        }

        public virtual async Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken)
        {
            var follow =
            await IncludeProperties(
                _followsContext.Follows)
                .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);

            return follow;
        }
    }
}

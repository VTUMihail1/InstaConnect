using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowByFollowerSortProperty
{
    public FollowByFollowerSortProperty SortProperty { get; }

    public Expression<Func<Follow, object>> Property { get; }
}

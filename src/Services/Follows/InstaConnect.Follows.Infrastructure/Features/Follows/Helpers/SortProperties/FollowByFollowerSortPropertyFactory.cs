using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Common.Infrastructure.FollowSortPropertys;
internal class FollowByFollowerSortPropertyFactory : IFollowByFollowerSortPropertyFactory
{
    private readonly IEnumerable<IFollowByFollowerSortProperty> _followByFollowerSortProperties;

    public FollowByFollowerSortPropertyFactory(IEnumerable<IFollowByFollowerSortProperty> followByFollowerSortProperties)
    {
        _followByFollowerSortProperties = followByFollowerSortProperties;
    }

    public IFollowByFollowerSortProperty Create(FollowByFollowerSortProperty sortProperty)
    {
        var property = _followByFollowerSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new FollowByFollowerSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

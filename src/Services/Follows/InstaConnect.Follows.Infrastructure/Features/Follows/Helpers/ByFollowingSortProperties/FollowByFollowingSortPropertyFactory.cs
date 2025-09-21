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

namespace InstaConnect.Posts.Infrastructure.Features.Follows.Helpers.SortProperties;
internal class FollowByFollowingSortPropertyFactory : IFollowByFollowingSortPropertyFactory
{
    private readonly IEnumerable<IFollowByFollowingSortProperty> _followByFollowingSortProperty;

    public FollowByFollowingSortPropertyFactory(IEnumerable<IFollowByFollowingSortProperty> followByFollowingSortProperty)
    {
        _followByFollowingSortProperty = followByFollowingSortProperty;
    }

    public IFollowByFollowingSortProperty Create(FollowByFollowingSortProperty sortProperty)
    {
        var property = _followByFollowingSortProperty.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new FollowByFollowingSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

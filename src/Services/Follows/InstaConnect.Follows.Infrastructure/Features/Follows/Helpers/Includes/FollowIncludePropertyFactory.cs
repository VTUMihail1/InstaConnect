using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Follows.Domain.Features.Follows.Exceptions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Common.Infrastructure.FollowSortPropertys;
internal class FollowIncludePropertyFactory : IFollowIncludePropertyFactory
{
    private readonly IEnumerable<IFollowIncludeProperty> _followIncludeProperty;

    public FollowIncludePropertyFactory(IEnumerable<IFollowIncludeProperty> followIncludeProperty)
    {
        _followIncludeProperty = followIncludeProperty;
    }

    public ICollection<IFollowIncludeProperty> Create(ICollection<FollowIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _followIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new FollowIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}

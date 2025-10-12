using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.PostSortPropertys;
internal class PostIncludePropertyFactory : IPostIncludePropertyFactory
{
    private readonly IEnumerable<IPostIncludeProperty> _postIncludeProperty;

    public PostIncludePropertyFactory(IEnumerable<IPostIncludeProperty> postIncludeProperty)
    {
        _postIncludeProperty = postIncludeProperty;
    }

    public ICollection<IPostIncludeProperty> Create(ICollection<PostIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.PostSortPropertys;
internal class PostSortPropertyFactory : IPostSortPropertyFactory
{
    private readonly IEnumerable<IPostSortProperty> _postSortProperties;

    public PostSortPropertyFactory(IEnumerable<IPostSortProperty> postSortProperties)
    {
        _postSortProperties = postSortProperties;
    }

    public IPostSortProperty Create(PostSortProperty sortProperty)
    {
        var property = _postSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

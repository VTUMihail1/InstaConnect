using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.PostSortPropertys;
internal class PostSortPropertyFactory : IPostSortPropertyFactory
{
    private readonly IEnumerable<IPostSortProperty> _postSortProperty;

    public PostSortPropertyFactory(IEnumerable<IPostSortProperty> postSortProperty)
    {
        _postSortProperty = postSortProperty;
    }

    public IPostSortProperty Get(PostSortProperty sortProperty)
    {
        var property = _postSortProperty.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostSortPropertyNotSupportedException();
        }

        return property;
    }
}

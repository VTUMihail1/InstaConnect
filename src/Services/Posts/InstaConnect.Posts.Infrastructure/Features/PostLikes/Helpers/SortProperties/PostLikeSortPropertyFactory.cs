using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.PostLikeSortPropertys;
internal class PostLikeSortPropertyFactory : IPostLikeSortPropertyFactory
{
    private readonly IEnumerable<IPostLikeSortProperty> _postLikeSortProperties;

    public PostLikeSortPropertyFactory(IEnumerable<IPostLikeSortProperty> postLikeSortProperties)
    {
        _postLikeSortProperties = postLikeSortProperties;
    }

    public IPostLikeSortProperty Create(PostLikeSortProperty sortProperty)
    {
        var property = _postLikeSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostLikeSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

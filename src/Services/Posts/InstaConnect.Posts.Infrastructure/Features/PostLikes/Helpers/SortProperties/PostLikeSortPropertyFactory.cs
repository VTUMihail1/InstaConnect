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

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortProperties;
internal class PostLikeSortPropertyFactory : IPostLikeSortPropertyFactory
{
    private readonly IEnumerable<IPostLikeSortProperty> _postLikeSortProperty;

    public PostLikeSortPropertyFactory(IEnumerable<IPostLikeSortProperty> postLikeSortProperty)
    {
        _postLikeSortProperty = postLikeSortProperty;
    }

    public IPostLikeSortProperty Create(PostLikeSortProperty sortProperty)
    {
        var property = _postLikeSortProperty.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostLikeSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Common.Infrastructure.PostLikeSortPropertys;
internal class PostLikeIncludePropertyFactory : IPostLikeIncludePropertyFactory
{
    private readonly IEnumerable<IPostLikeIncludeProperty> _postLikeIncludeProperty;

    public PostLikeIncludePropertyFactory(IEnumerable<IPostLikeIncludeProperty> postLikeIncludeProperty)
    {
        _postLikeIncludeProperty = postLikeIncludeProperty;
    }

    public ICollection<IPostLikeIncludeProperty> Create(ICollection<PostLikeIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postLikeIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostLikeIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}

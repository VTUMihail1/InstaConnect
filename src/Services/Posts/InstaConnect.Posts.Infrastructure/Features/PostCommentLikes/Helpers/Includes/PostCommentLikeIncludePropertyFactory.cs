using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Exceptions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Common.Infrastructure.PostCommentLikeSortPropertys;
internal class PostCommentLikeIncludePropertyFactory : IPostCommentLikeIncludePropertyFactory
{
    private readonly IEnumerable<IPostCommentLikeIncludeProperty> _postCommentLikeIncludeProperty;

    public PostCommentLikeIncludePropertyFactory(IEnumerable<IPostCommentLikeIncludeProperty> postCommentLikeIncludeProperty)
    {
        _postCommentLikeIncludeProperty = postCommentLikeIncludeProperty;
    }

    public ICollection<IPostCommentLikeIncludeProperty> Create(ICollection<PostCommentLikeIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postCommentLikeIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostCommentLikeIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Exceptions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Common.Infrastructure.PostCommentSortPropertys;
internal class PostCommentIncludePropertyFactory : IPostCommentIncludePropertyFactory
{
    private readonly IEnumerable<IPostCommentIncludeProperty> _postCommentIncludeProperty;

    public PostCommentIncludePropertyFactory(IEnumerable<IPostCommentIncludeProperty> postCommentIncludeProperty)
    {
        _postCommentIncludeProperty = postCommentIncludeProperty;
    }

    public ICollection<IPostCommentIncludeProperty> Create(ICollection<PostCommentIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postCommentIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new PostCommentIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}

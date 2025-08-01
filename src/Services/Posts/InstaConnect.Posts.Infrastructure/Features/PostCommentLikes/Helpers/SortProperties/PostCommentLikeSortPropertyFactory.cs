using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortProperties;
internal class PostCommentLikeSortPropertyFactory : IPostCommentLikeSortPropertyFactory
{
    private readonly IEnumerable<IPostCommentLikeSortProperty> _postCommentLikeSortProperty;

    public PostCommentLikeSortPropertyFactory(IEnumerable<IPostCommentLikeSortProperty> postCommentLikeSortProperty)
    {
        _postCommentLikeSortProperty = postCommentLikeSortProperty;
    }

    public IPostCommentLikeSortProperty Create(PostCommentLikeSortProperty sortProperty)
    {
        var property = _postCommentLikeSortProperty.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostCommentLikeSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

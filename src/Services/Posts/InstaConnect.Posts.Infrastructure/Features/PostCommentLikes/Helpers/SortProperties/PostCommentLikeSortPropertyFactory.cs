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

namespace InstaConnect.Common.Infrastructure.PostCommentLikeSortPropertys;
internal class PostCommentLikeSortPropertyFactory : IPostCommentLikeSortPropertyFactory
{
    private readonly IEnumerable<IPostCommentLikeSortProperty> _postCommentLikeSortProperties;

    public PostCommentLikeSortPropertyFactory(IEnumerable<IPostCommentLikeSortProperty> postCommentLikeSortProperties)
    {
        _postCommentLikeSortProperties = postCommentLikeSortProperties;
    }

    public IPostCommentLikeSortProperty Create(PostCommentLikeSortProperty sortProperty)
    {
        var property = _postCommentLikeSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostCommentLikeSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

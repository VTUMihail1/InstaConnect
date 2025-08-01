using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortProperties;
internal class PostCommentSortPropertyFactory : IPostCommentSortPropertyFactory
{
    private readonly IEnumerable<IPostCommentSortProperty> _postCommentSortProperty;

    public PostCommentSortPropertyFactory(IEnumerable<IPostCommentSortProperty> postCommentSortProperty)
    {
        _postCommentSortProperty = postCommentSortProperty;
    }

    public IPostCommentSortProperty Create(PostCommentSortProperty sortProperty)
    {
        var property = _postCommentSortProperty.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostCommentSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

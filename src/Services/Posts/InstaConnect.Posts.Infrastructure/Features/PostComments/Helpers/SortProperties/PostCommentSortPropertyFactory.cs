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

namespace InstaConnect.Common.Infrastructure.PostCommentSortPropertys;
internal class PostCommentSortPropertyFactory : IPostCommentSortPropertyFactory
{
    private readonly IEnumerable<IPostCommentSortProperty> _postCommentSortProperties;

    public PostCommentSortPropertyFactory(IEnumerable<IPostCommentSortProperty> postCommentSortProperties)
    {
        _postCommentSortProperties = postCommentSortProperties;
    }

    public IPostCommentSortProperty Create(PostCommentSortProperty sortProperty)
    {
        var property = _postCommentSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new PostCommentSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}

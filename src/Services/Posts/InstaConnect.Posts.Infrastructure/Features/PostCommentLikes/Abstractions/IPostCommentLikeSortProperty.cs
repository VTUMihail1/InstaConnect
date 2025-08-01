using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty { get; }

    public string Property { get; }
}

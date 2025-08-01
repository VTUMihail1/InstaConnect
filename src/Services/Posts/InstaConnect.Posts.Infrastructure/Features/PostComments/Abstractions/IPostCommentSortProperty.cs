using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty { get; }

    public string Property { get; }
}

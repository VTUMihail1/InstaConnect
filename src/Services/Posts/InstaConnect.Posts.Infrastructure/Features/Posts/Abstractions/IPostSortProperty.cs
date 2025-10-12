using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostSortProperty
{
    public PostSortProperty SortProperty { get; }

    public Expression<Func<Post, object>> Property { get; }
}

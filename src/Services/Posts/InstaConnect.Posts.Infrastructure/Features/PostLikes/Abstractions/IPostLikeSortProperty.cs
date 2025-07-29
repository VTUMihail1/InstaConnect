using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty { get; }

    public string Property { get; }
}

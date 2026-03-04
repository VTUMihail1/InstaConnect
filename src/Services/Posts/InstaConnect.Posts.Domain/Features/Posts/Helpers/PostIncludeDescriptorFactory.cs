using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

public class PostIncludeDescriptorFactory : IPostIncludeDescriptorFactory
{
    public PostsIncludeDescriptor CreateUser()
    {
        return new(PostsDestinationType.Post, PostsIncludeType.User);
    }

    public PostsIncludeDescriptor CreatePostLikes()
    {
        return new(PostsDestinationType.Post, PostsIncludeType.PostLike);
    }

    public PostsIncludeDescriptor CreatePostComments()
    {
        return new(PostsDestinationType.Post, PostsIncludeType.PostComment);
    }
}

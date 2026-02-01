using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

public class PostLikeIncludeDescriptorFactory : IPostLikeIncludeDescriptorFactory
{
    public PostsIncludeDescriptor CreateUser()
    {
        return new(PostsDestinationType.PostLikes, PostsIncludeType.Users);
    }

    public PostsIncludeDescriptor CreatePost()
    {
        return new(PostsDestinationType.PostLikes, PostsIncludeType.Posts);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
    public PostsIncludeDescriptor CreatePosts()
    {
        return new(PostsDestinationType.Users, PostsIncludeType.Posts);
    }

    public PostsIncludeDescriptor CreatePostLikes()
    {
        return new(PostsDestinationType.Users, PostsIncludeType.PostLikes);
    }

    public PostsIncludeDescriptor CreatePostComments()
    {
        return new(PostsDestinationType.Users, PostsIncludeType.PostComments);
    }

    public PostsIncludeDescriptor CreatePostCommentLikes()
    {
        return new(PostsDestinationType.Users, PostsIncludeType.PostCommentLikes);
    }
}

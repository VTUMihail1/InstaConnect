using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

public class PostCommentIncludeDescriptorFactory : IPostCommentIncludeDescriptorFactory
{
    public PostsIncludeDescriptor CreateUser()
    {
        return new(PostsDestinationType.PostComments, PostsIncludeType.Users);
    }

    public PostsIncludeDescriptor CreatePost()
    {
        return new(PostsDestinationType.PostComments, PostsIncludeType.Posts);
    }

    public PostsIncludeDescriptor CreatePostCommentLikes()
    {
        return new(PostsDestinationType.PostComments, PostsIncludeType.PostCommentLikes);
    }
}

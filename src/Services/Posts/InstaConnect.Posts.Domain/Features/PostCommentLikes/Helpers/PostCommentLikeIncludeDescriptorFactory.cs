using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

public class PostCommentLikeIncludeDescriptorFactory : IPostCommentLikeIncludeDescriptorFactory
{
    public PostsIncludeDescriptor CreateUser()
    {
        return new(PostsDestinationType.PostCommentLikes, PostsIncludeType.Users);
    }

    public PostsIncludeDescriptor CreatePostComment()
    {
        return new(PostsDestinationType.PostCommentLikes, PostsIncludeType.PostComments);
    }
}

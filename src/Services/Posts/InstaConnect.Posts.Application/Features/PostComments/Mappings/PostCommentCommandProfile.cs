using AutoMapper;

using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

namespace InstaConnect.Posts.Application.Features.PostComments.Mappings;

public class PostCommentCommandProfile : Profile
{
    public PostCommentCommandProfile()
    {
        CreateMap<PostComment, PostCommentCommandViewModel>();
    }
}

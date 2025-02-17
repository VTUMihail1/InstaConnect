using AutoMapper;

using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<AddPostCommentLikeRequest, AddPostCommentLikeCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.Body.PostCommentId));

        CreateMap<DeletePostCommentLikeRequest, DeletePostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId));

        CreateMap<PostCommentLikeCommandViewModel, PostCommentLikeCommandResponse>();
    }
}

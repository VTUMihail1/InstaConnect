using AutoMapper;

using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<AddPostCommentLikeRequest, AddPostCommentLikeCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.PostId, src.PostCommentId));

        CreateMap<DeletePostCommentLikeRequest, DeletePostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Id, src.PostId, src.PostCommentId, src.CurrentUserId));

        CreateMap<PostCommentLikeCommandViewModel, PostCommentLikeCommandResponse>();
    }
}

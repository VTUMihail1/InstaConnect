using AutoMapper;

using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;

internal class PostLikeQueryProfile : Profile
{
    public PostLikeQueryProfile()
    {
        CreateMap<GetAllPostLikesRequest, GetAllPostLikesQueryRequest>();

        CreateMap<GetPostLikeByIdRequest, GetPostLikeByIdQueryRequest>();

        CreateMap<PostLikeQueryViewModel, PostLikeQueryResponse>();

        CreateMap<PostLikePaginationQueryViewModel, PostLikePaginationQueryResponse>();
    }
}

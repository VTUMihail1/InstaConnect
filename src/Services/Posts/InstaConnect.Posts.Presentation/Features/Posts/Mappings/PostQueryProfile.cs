using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<GetAllPostsRequest, GetAllPostsQuery>();

        CreateMap<GetPostByIdRequest, GetPostByIdQuery>();

        CreateMap<PostQueryViewModel, PostQueryResponse>();

        CreateMap<PostPaginationQueryViewModel, PostPaginationQueryResponse>();
    }
}

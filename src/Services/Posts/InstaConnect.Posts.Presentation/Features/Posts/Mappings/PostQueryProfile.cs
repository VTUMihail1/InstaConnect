using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<PostPaginationRequest, PostQueryPagination>();

        CreateMap<PostSortingApiRequest, PostQuerySorting>();

        CreateMap<PostPaginationApiRequest, PostQueryPagination>();

        CreateMap<PostPaginationRequest, PostQueryPagination>();

        CreateMap<GetAllPostsApiRequest, GetAllPostsQuery>();

        CreateMap<GetPostByIdApiRequest, GetPostByIdQuery>();

        CreateMap<GetPostByIdQueryResponse, GetPostByIdApiResponse>();

        CreateMap<GetAllPostsQueryResponse, GetAllPostsApiResponse>();
    }
}

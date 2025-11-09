using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostsApiRequest, GetAllPostsQueryRequest>()
            .ConstructUsing(src => new(
                new(src.Filter.UserId, src.Filter.UserName, src.Filter.Title),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllPostsQueryResponse, GetAllPostsApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostApiResponse(
                                      p.Id,
                                      p.Title,
                                      p.Content,
                                      new(
                                          p.User.Id,
                                          p.User.Name,
                                          p.User.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostByIdApiRequest, GetPostByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<GetPostByIdQueryResponse, GetPostByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    src.Data.Title,
                    src.Data.Content,
                    new(
                        src.Data.User.Id,
                        src.Data.User.Name,
                        src.Data.User.ProfileImage))));

        config.NewConfig<AddPostApiRequest, AddPostCommandRequest>()
            .ConstructUsing(src => new(src.UserId, src.Body.Title, src.Body.Content));

        config.NewConfig<AddPostCommandResponse, AddPostApiResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdatePostApiRequest, UpdatePostCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.UserId, src.Body.Title, src.Body.Content));

        config.NewConfig<UpdatePostCommandResponse, UpdatePostApiResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostApiRequest, DeletePostCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.UserId));
    }
}

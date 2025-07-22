using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

using Mapster;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

public class PostApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostsQueryRequest, GetAllPostsQuery>()
            .ConstructUsing(src => new(
                new(src.Filter.UserId, src.Filter.UserName, src.Filter.Title),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<PostCollection, GetAllPostsQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostQueryResponse(
                                      p.Id,
                                      p.Title,
                                      p.Content,
                                      new(
                                          p.UserId,
                                          p.User!.UserName,
                                          p.User.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostByIdQueryRequest, GetPostByIdQuery>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<Post, GetPostByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    src.Title,
                    src.Content,
                    new(
                        src.UserId,
                        src.User!.UserName,
                        src.User.ProfileImage))));

        config.NewConfig<AddPostCommandRequest, AddPostCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.Title, src.Content));

        config.NewConfig<Post, AddPostCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdatePostCommandRequest, UpdatePostCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId, src.Title, src.Content));

        config.NewConfig<Post, UpdatePostCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostCommandRequest, DeletePostCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId));
    }
}

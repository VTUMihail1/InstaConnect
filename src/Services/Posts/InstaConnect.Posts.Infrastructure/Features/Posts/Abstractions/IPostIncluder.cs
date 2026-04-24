using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

internal interface IPostIncluder : IIncluder<Post, PostsIncludeType, PostsDestinationType>;

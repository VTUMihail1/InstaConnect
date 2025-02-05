using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;

public record AddPostLikeCommand(string CurrentUserId, string PostId) : ICommand<PostLikeCommandViewModel>;

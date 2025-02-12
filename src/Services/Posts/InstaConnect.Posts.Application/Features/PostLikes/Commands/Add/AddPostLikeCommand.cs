using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeCommand(string CurrentUserId, string PostId) : ICommand<PostLikeCommandViewModel>;

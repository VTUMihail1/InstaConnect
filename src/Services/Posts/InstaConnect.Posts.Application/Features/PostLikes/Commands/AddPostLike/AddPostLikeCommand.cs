using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;

public record AddPostLikeCommand(string CurrentUserId, string PostId) : ICommand<PostLikeCommandViewModel>;

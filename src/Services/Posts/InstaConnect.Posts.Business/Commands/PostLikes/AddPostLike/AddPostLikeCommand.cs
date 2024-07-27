using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;

public record AddPostLikeCommand(string CurrentUserId, string PostId) : ICommand<PostLikeCommandViewModel>;

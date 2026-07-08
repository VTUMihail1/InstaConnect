namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeCommandBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;

	public AddPostCommentLikeCommandBuilder(PostComment postComment, User user)
	{
		_id = postComment.Id.Id.Id;
		_commentId = postComment.Id.CommentId;
		_userId = user.Id.Id;
	}

	public AddPostCommentLikeCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddPostCommentLikeCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddPostCommentLikeCommandBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public AddPostCommentLikeCommandBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public AddPostCommentLikeCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostCommentLikeCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostCommentLikeCommand Build()
	{
		return new(
			new(
				new(_id),
				_commentId),
			new(_userId));
	}
}

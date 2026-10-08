namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeCommandBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;

	public DeletePostCommentLikeCommandBuilder(PostCommentLike postCommentLike)
	{
		_id = postCommentLike.Id.CommentId.Id.Id;
		_commentId = postCommentLike.Id.CommentId.CommentId;
		_userId = postCommentLike.Id.UserId.Id;
	}

	public DeletePostCommentLikeCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeletePostCommentLikeCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeletePostCommentLikeCommandBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public DeletePostCommentLikeCommandBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public DeletePostCommentLikeCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public DeletePostCommentLikeCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public DeletePostCommentLikeCommand Build()
	{
		return new(
			new(
				new(
					new(_id),
					_commentId),
				new(_userId)));
	}
}

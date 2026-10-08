namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class DeletePostCommentCommandBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;

	public DeletePostCommentCommandBuilder(PostComment postComment)
	{
		_id = postComment.Id.Id.Id;
		_commentId = postComment.Id.CommentId;
		_userId = postComment.UserId.Id;
	}

	public DeletePostCommentCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeletePostCommentCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeletePostCommentCommandBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public DeletePostCommentCommandBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public DeletePostCommentCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public DeletePostCommentCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public DeletePostCommentCommand Build()
	{
		return new(
			new(
				new(_id),
				_commentId),
			new(_userId));
	}
}

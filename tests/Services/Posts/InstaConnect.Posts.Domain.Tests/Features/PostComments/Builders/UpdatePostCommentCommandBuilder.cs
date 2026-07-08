namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class UpdatePostCommentCommandBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;
	private string _content;

	public UpdatePostCommentCommandBuilder(PostComment postComment)
	{
		_id = postComment.Id.Id.Id;
		_commentId = postComment.Id.CommentId;
		_userId = postComment.UserId.Id;
		_content = PostCommentDataFaker.GetContent();
	}

	public UpdatePostCommentCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UpdatePostCommentCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UpdatePostCommentCommandBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public UpdatePostCommentCommandBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public UpdatePostCommentCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public UpdatePostCommentCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public UpdatePostCommentCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public UpdatePostCommentCommand Build()
	{
		return new(
			new(
				new(_id),
				_commentId),
			new(_userId),
			_content);
	}
}

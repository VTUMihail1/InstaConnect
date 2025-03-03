﻿namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Utilities;
public abstract class PostCommentTestRoutes
{
    public const string Default = "api/v1/post-comments";

    public const string GetAll = "api/v1/post-comments?&userId={0}&userName={1}&postId={2}&sortOrder={3}&sortPropertyName={4}&page={5}&pageSize={6}";

    public const string Id = "api/v1/post-comments/{0}";
}

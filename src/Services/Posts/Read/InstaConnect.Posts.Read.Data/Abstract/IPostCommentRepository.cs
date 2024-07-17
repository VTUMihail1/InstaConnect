﻿using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Read.Data.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing post comments, inheriting from the generic repository for entities of type <see cref="PostComment"/>.
/// </summary>
public interface IPostCommentRepository : IBaseReadRepository<PostComment>
{ }

﻿using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPost
{
    public class AddPostCommand : ICommand
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
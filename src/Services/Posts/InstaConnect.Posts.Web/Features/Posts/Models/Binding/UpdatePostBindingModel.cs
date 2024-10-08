﻿namespace InstaConnect.Posts.Web.Features.Posts.Models.Binding;

public class UpdatePostBindingModel
{
    public UpdatePostBindingModel(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}

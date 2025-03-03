﻿namespace InstaConnect.Messages.Application.Features.Messages.Models;

public record MessageQueryViewModel(
    string Id,
    string SenderId,
    string SenderName,
    string? SenderProfileImage,
    string ReceiverId,
    string ReceiverName,
    string? ReceiverProfileImage,
    string Content
);

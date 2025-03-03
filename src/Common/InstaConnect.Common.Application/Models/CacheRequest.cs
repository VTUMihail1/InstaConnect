﻿namespace InstaConnect.Shared.Application.Models;

public record CacheRequest(
    string Key,
    object? Data,
    DateTime Expiration);

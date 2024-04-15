﻿using EGames.Data.Models.Entities;

namespace EGames.Data.Factories.Abstract
{
    /// <summary>
    /// Represents a token factory interface for creating access tokens.
    /// </summary>
    internal interface ITokenFactory
    {
        /// <summary>
        /// Gets an access token with the specified parameters.
        /// </summary>
        /// <param name="userId">The unique identifier of the user for whom the access token is created.</param>
        /// <param name="value">The value of the access token.</param>
        /// <param name="type">The type of the access token.</param>
        /// <param name="validUntil">The validity duration of the access token in seconds.</param>
        /// <returns>A <see cref="Token"/> representing the created access token.</returns>
        Token GetTokenToken(string userId, string value, string type, int validUntil);
    }
}
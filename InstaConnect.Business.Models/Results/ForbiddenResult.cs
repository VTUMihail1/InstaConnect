﻿using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Results
{
    public class ForbiddenResult<T> : IResult<T>
    {
        public ForbiddenResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public InstaConnectStatusCode StatusCode => InstaConnectStatusCode.Forbidden;

        public IEnumerable<string> ErrorMessages { get; set; }

        public T Data { get; }
    }
}

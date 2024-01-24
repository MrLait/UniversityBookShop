using System;
using System.Collections.Generic;
using System.Linq;
namespace UniversityBookShop.Application.Common.Models
{
    public static class ServiceErrorConstants
    {
        public const string DefaultError = "An exception occured.";
        public const string NotFound = "The requested data was not found on this server.";
    }

    public static class ServiceStatusCodeConstants
    {
        public const int DefaultStatusCode = 999;
        public const int NotFoundStatusCode = 404;
    }

    public class ServiceError
    {
        public string Message { get; }
        public int StatusCode { get; }

        public ServiceError(string message, int statusCode) => 
            (Message, StatusCode) = (message, statusCode);

        public static ServiceError DefaultError => new ServiceError(ServiceErrorConstants.DefaultError, ServiceStatusCodeConstants.DefaultStatusCode);

        public static ServiceError NotFound => new ServiceError(ServiceErrorConstants.NotFound, ServiceStatusCodeConstants.NotFoundStatusCode);
    }
}

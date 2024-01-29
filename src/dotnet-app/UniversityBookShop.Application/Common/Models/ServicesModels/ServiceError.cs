using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.ServicesModels
{
    public class ServiceError
    {
        public string Message { get; }
        public int StatusCode { get; }

        public ServiceError(string message, int statusCode) =>
            (Message, StatusCode) = (message, statusCode);

        public static ServiceError DefaultError => new ServiceError(ServiceErrorConstants.DefaultError, ServiceStatusCodeConstants.DefaultStatusCode);
        public static ServiceError NotFound => new ServiceError(ServiceErrorConstants.NotFound, ServiceStatusCodeConstants.NotFoundStatusCode);
        public static ServiceError Validation => new ServiceError(ServiceErrorConstants.ValidationError, ServiceStatusCodeConstants.ValidationtStatusCode);
        public static ServiceError BookPurchaseFacultyError => 
            new ServiceError(ServiceErrorConstants.BookPurchaseFacultyError, ServiceStatusCodeConstants.BookPurchaseFacultyErrorStatusCode); 
        public static ServiceError BookPurchaseUniversityError => 
            new ServiceError(ServiceErrorConstants.BookPurchaseUniversityError, ServiceStatusCodeConstants.BookPurchaseUniversiyErrorStatusCode);

        public static ServiceError CustomMessage(string message, int statusCode)
        {
            return new ServiceError(message, statusCode);
        }
    }
}

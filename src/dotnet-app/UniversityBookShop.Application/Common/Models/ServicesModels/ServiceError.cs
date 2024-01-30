using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.ServicesModels
{
    public class ServiceError
    {
        public string Message { get; }
        public int StatusCode { get; }

        public ServiceError(string message, int statusCode) =>
            (Message, StatusCode) = (message, statusCode);

        public static ServiceError DefaultError => new(ServiceErrorConstants.DefaultError, ServiceStatusCodeConstants.DefaultStatusCode);
        public static ServiceError NotFound => new(ServiceErrorConstants.NotFound, ServiceStatusCodeConstants.NotFoundStatusCode);
        public static ServiceError Validation => new(ServiceErrorConstants.ValidationError, ServiceStatusCodeConstants.ValidationtStatusCode);

        public static ServiceError BookPurchaseFacultyError =>
            new(ServiceErrorConstants.BookPurchaseFacultyError, ServiceStatusCodeConstants.BookPurchaseFacultyErrorStatusCode);
        public static ServiceError BookPurchaseUniversityError => 
            new(ServiceErrorConstants.BookPurchaseUniversityError, ServiceStatusCodeConstants.BookPurchaseUniversiyErrorStatusCode);
        public static ServiceError ThereIsNoUniversityForFaculty => 
            new(ServiceErrorConstants.ThereIsNoUniversityForFacultyError, ServiceStatusCodeConstants.ThereIsNoUniversityForFacultyStatusCode);
        public static ServiceError EntityAlreadyExists =>
            new(ServiceErrorConstants.EntityAlreadyExistsError, ServiceStatusCodeConstants.EntityAlreadyExistsStatusCode);
        public static ServiceError CantDeleteUnivarstityBook =>
            new(ServiceErrorConstants.CantDeleteUnivarstityBookError, ServiceStatusCodeConstants.CantDeleteUnivarstityBookStatusCode);

        public static ServiceError CustomMessage(string message, int statusCode) => new(message, statusCode);
    }
}

using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.ServicesModels
{
    public class ServiceError
    {
        public string Message { get; }
        public int StatusCode { get; }

        public ServiceError(string message, int statusCode) =>
            (Message, StatusCode) = (message, statusCode);

        public static ServiceError DefaultError => new(ApplicationConstants.Service.Error.Default, ApplicationConstants.Service.StatusCode.Default);
        public static ServiceError NotFound => new(ApplicationConstants.Service.Error.NotFound, ApplicationConstants.Service.StatusCode.NotFound);
        public static ServiceError Validation => new(ApplicationConstants.Service.Error.Validation, ApplicationConstants.Service.StatusCode.Validationt);

        public static ServiceError BookPurchaseFacultyError =>
            new(ApplicationConstants.Service.Error.BookPurchaseFaculty, ApplicationConstants.Service.StatusCode.BookPurchaseFacultyError);
        public static ServiceError BookPurchaseUniversityError => 
            new(ApplicationConstants.Service.Error.BookPurchaseUniversity, ApplicationConstants.Service.StatusCode.BookPurchaseUniversiyError);
        public static ServiceError ThereIsNoUniversityForFaculty => 
            new(ApplicationConstants.Service.Error.ThereIsNoUniversityForFaculty, ApplicationConstants.Service.StatusCode.ThereIsNoUniversityForFaculty);
        public static ServiceError EntityAlreadyExists =>
            new(ApplicationConstants.Service.Error.EntityAlreadyExists, ApplicationConstants.Service.StatusCode.EntityAlreadyExists);
        public static ServiceError CantDeleteUnivarstityBook =>
            new(ApplicationConstants.Service.Error.CantDeleteUnivarstityBook, ApplicationConstants.Service.StatusCode.CantDeleteUnivarstityBook);
        public static ServiceError CantDeleteUnivarstity =>
            new(ApplicationConstants.Service.Error.CantDeleteUnivarstity, ApplicationConstants.Service.StatusCode.CantDeleteUnivarstity);
        public static ServiceError CantDeleteFacultyBookExist =>
           new(ApplicationConstants.Service.Error.CantDeleteFacultyBookExist, ApplicationConstants.Service.StatusCode.CantDeleteFacultyBookExist);
        
        public static ServiceError CustomMessage(string message, int statusCode) => new(message, statusCode);
    }
}

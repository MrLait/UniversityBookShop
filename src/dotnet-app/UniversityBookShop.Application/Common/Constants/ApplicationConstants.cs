namespace UniversityBookShop.Application.Common.Constants
{
    public static class ApplicationConstants
    {
        public class Pagination
        {
            public const int FirstPage = 1;
            public const int MaxPageSize = 50;
        }

        public static class PurchaseStatus
        {
            public const string BookPurchasedByCurrentFaculty = "Book has been purchased by the current faculty";
            public const string BookAddedByCurrentFaculty = "Book has been added by the current faculty";
            public const string BookAvailableForAdditionByCurrentFaculty = "Book available for addition by the current faculty for free";
            public const string BookAvailableForPurchase = "Book available for purchase";
        }

        public static class Service
        {
            public static class Error
            {
                public const string Validation = "One or more validation failures have occurred. Look for details of validation in the 'date' field.";
                public const string Default = "An exception occured.";
                public const string NotFound = "The requested data was not found on this server.";
                public const string FieldNotEmpty = "{PropertyName} should not be empty.";
                public const string GreaterThanZero = "{PropertyName} should be more than zero";
                public const string MustBeLessThan = "{PropertyName} must be less than {MaxLength} characters.";
                public const string PrecisionScale = "{PropertyName} should be a number with precision {ExpectedPrecision} and scale {ExpectedScale}";
                public const string PaginationMaxPageSize = "{PropertyName} more than {ComparisonValue} - maximum page size";

                public const string BookPurchaseUniversity = "This book for this university has already been purchased";
                public const string BookPurchaseFaculty = "This book for this faculty has already been purchased";
                public const string ThereIsNoUniversityForFaculty = "This faculty does not belong to this university.";
                public const string EntityAlreadyExists = "This entity already exists.";
                public const string CantDeleteUnivarstityBook = "Can't delete a purchased book that was added by other faculties.";
                public const string CantDeleteUnivarstity = "A university that has faculties cannot be deleted.";
                public const string CantDeleteFacultyBookExist = "A faculty that has books cannot be deleted.";
            }

            public static class StatusCode
            {
                public const int UnknownDatabase = 1049;
                public const int Default = 999;
                public const int Validation = 998;
                public const int BookPurchaseFacultyError = 997;
                public const int BookPurchaseUniversiyError = 996;
                public const int ThereIsNoUniversityForFaculty = 995;
                public const int EntityAlreadyExists = 994;
                public const int CantDeleteUnivarstityBook = 993;
                public const int CantDeleteUnivarstity = 992;
                public const int CantDeleteFacultyBookExist = 991;

                public const int NotFound = 404;
            }
        }
    }
}

namespace UniversityBookShop.Application.Common.Constants
{
    public static class ServiceErrorConstants
    {
        public const string ValidationError = "One or more validation failures have occurred. Look for details of validation in the 'date' field.";
        public const string DefaultError = "An exception occured.";
        public const string NotFound = "The requested data was not found on this server.";
        public const string FieldNotEmpty = "{PropertyName} should not be empty.";
        public const string GreaterThanZero = "{PropertyName} should be more than zero";
        public const string MustBeLessThan= "{PropertyName} must be less than {MaxLength} characters.";
        public const string PrecisionScale = "{PropertyName} should be a number with precision {ExpectedPrecision} and scale {ExpectedScale}";
        public const string PaginationMaxPageSizeError = "{PropertyName} more than {ComparisonValue} - maximum page size";

        public const string BookPurchaseUniversityError = "This book for this university has already been purchased";
        public const string BookPurchaseFacultyError = "This book for this faculty has already been purchased";
        public const string ThereIsNoUniversityForFacultyError = "This faculty does not belong to this university.";
        public const string EntityAlreadyExistsError = "This entity already exists.";
        public const string CantDeleteUnivarstityBookError = "Can't delete a purchased book that was added by other faculties.";
        public const string CantDeleteUnivarstityError = "A university that has faculties cannot be deleted.";

        


    }
}

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


    }
}

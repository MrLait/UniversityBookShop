namespace UniversityBookShop.Api.Constants
{
    public static class RoutingConstants
    {
        public const string ApiController = "api/[controller]";
        public const string Id = "{id}";

        public static class Faculty
        {
            public const string FacultyId = "{facultyId}";
            public const string UniversityId = "university/{universityId}";
        }

        public static class Book
        {
            public const string FacultyId = "faculty/{facultyId}";
        }

        public static class PurchasedBookFaculty
        {
            public const string FacultyIdAndBookId = "faculty/{facultyId}/book/{bookId}";
            public const string FacultyId = "faculty/{facultyId}";
            public const string UniversityId = "university/{universityId}";
        }

        public static class University
        {
            public const string UniversityId = "{universityId}";
        }

        public static class BooksAvailableForFaculty
        {
            public const string Add = "add/";
            public const string FacultyId = "{facultyId}";
            public const string FacultyIdBookId = "{facultyId}/{bookId}";

        }
    }
}

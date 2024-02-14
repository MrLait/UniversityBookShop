namespace UniversityBookShop.Api.Constants
{
    public static class RoutingConstants
    {
        public const string ApiController = "api/[controller]";

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


        public const string UniversityId = "{universityId}";
        public const string UniversityAndId = "university/{id}";
        public const string Id = "{id}";
        public const string FacultyId = "{facultyId}";
        public const string FacultyAndId = "faculty/{id}";
        
        public const string FacultyIdBookId = "{facultyId}/{bookId}";
        public const string Add = "add/";
    }
}

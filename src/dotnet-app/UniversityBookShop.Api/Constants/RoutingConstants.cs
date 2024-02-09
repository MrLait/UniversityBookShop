namespace UniversityBookShop.Api.Constants
{
    public static class RoutingConstants
    {
        public static class Faculty{
            public const string FacultyId = "{facultyId}";
            public const string UniversityId = "university/{universityId}";
        }

        public const string ApiController = "api/[controller]";
        public const string UniversityId = "{universityId}";
        public const string UniversityAndId = "university/{id}";
        public const string Id = "{id}";
        public const string FacultyId = "{facultyId}";
        public const string FacultyAndId = "faculty/{id}";
        
        public const string FacultyIdBookId = "{facultyId}/{bookId}";
        public const string Add = "add/";
    }
}

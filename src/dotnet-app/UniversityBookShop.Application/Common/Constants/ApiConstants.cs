namespace UniversityBookShop.Application.Common.Constants
{
    public static class ApiConstants
    {
        public static class Policy
        {
            public const string Authorization = "ApiScope";
            public const string Cors= "reactApp";
        }

        public static class Identity
        {
            public const string IdentityAuthority = "IDENTITY_AUTHORITY";
            public const string WebScope = "UniversityBookShop.Api";

            //public const string ApiScopePolicy = "ApiScope";
            public const string ClaimTypeScope = "scope";
        }

        public static class Routing
        {
            public const string ApiController = $"api/[controller]";
            public const string ApiControllerAction = $"api/[controller]/[action]";

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

        public static class Swagger
        {
            public const string Version = "v1";
            public const string Name = "University book shop API " + Version;
            public const string Url = "/swagger/v1/swagger.json";
        }
    }
}

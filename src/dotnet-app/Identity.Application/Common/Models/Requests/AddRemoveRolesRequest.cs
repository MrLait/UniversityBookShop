namespace Identity.Application.Common.Models.Requests
{
    public class AddRemoveRolesRequest
    {
        public string UserName { get; set; }

        public string[] RoleNames { get; set; }
    }
}
namespace Identity.Application.Common.Models.Responses
{
    public class IdentityApiResponse<T>
    {
        public T Payload { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
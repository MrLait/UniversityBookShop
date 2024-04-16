namespace IdentityServer.Application.Common.Options
{
    public class ServiceAdressOptions
    {
        public const string SectionName = nameof(ServiceAdressOptions);
        public string IdentityServerApi { get; set; }
        public string IdentityApi { get; set; }
    }
}
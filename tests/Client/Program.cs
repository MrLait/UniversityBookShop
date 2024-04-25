using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer.Application.Common.Options;
using Client.HttpClients.IdentityServerApi;
using Client.HttpClients.IdentityApi;

namespace Client
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient<IdentityServerClient>();
                    services.AddHttpClient<UserClient>();

                    services.AddTransient<AuthenticationServiceTest>();

                    var configurationBuilder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false);

                    IConfiguration configuration = configurationBuilder.Build();

                    services.Configure<IdentityServerApiOptions>(configuration.GetSection(IdentityServerApiOptions.SectionName));
                    services.Configure<ServiceAdressOptions>(configuration.GetSection(ServiceAdressOptions.SectionName));
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var service = services.GetRequiredService<AuthenticationServiceTest>();

                    var usersResult = await service.RunUsersClientTests(args);

                    Console.WriteLine(usersResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured: {ex.Message}");
                }
            }

            Console.ReadKey();

            return 0;
        }
    }
}


//using IdentityModel.Client;
//using Newtonsoft.Json.Linq;
//using static System.Net.WebRequestMethods;

//namespace Client
//{
//    public class Program
//    {
//        private static async Task Main()
//        {
//            // discover endpoints from metadata
//            var client = new HttpClient();

//            var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
//            {
//                Address = "http://identityserverapi",
//                //Address = "http://localhost:32777",
//                Policy = { RequireHttps = false },
//            });

//            if (disco.IsError) 
//                {
//                Console.WriteLine(disco.Error);
//                return;
//            }

//            // request token
//            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
//            {
//                Address = disco.TokenEndpoint,
//                ClientId = "test.client",
//                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",

//                Scope = "Api"
//            });

//            if (tokenResponse.IsError)
//            {
//                Console.WriteLine(tokenResponse.Error);
//                return;
//            }

//            Console.WriteLine(tokenResponse.Json);
//            Console.WriteLine("\n\n");

//            // call api
//            var apiClient = new HttpClient();
//            apiClient.SetBearerToken(tokenResponse.AccessToken);

//            var response = await apiClient.GetAsync("http://localhost:5002/HealthCheck");
//            if (!response.IsSuccessStatusCode)
//            {
//                Console.WriteLine(response.StatusCode);
//            }
//            else
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                Console.WriteLine(JArray.Parse(content));
//            }
//        }
//    }
//}
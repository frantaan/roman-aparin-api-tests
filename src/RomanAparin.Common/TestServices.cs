using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RomanAparin.Common.Clients;
using System;


namespace RomanAparin.Common
{
    public static class TestServices
    {
        private static ServiceProvider ServiceProvider { get; set; }
        public static IOptions<TestServicesOptions> TestServiceOptions { get; private set; }
        public static IDevApiClient DevApiClient { get; set; }
        public static string NewId => Guid.NewGuid().ToString();
        public static readonly Random Random = new Random(Environment.TickCount);
        public static long Timestamp { get; set; }
        static TestServices() => ConfigureServices();

        private static void ConfigureServices()
        {
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            ServiceProvider = GetServiceProvider(configuration);
            TestServiceOptions = ServiceProvider.GetService<IOptions<TestServicesOptions>>()!;
            DevApiClient = ServiceProvider.GetService<IDevApiClient>()!;
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        private static ServiceProvider GetServiceProvider(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.Configure<TestServicesOptions>(option =>
            {
                option.BaseUrl = configuration.GetSection("TestServicesOptions").GetSection("BaseUrl").Value;
            });
            services.AddSingleton<IBaseHttpClient, BaseHttpClient>();
            services.AddSingleton<IDevApiClient, DevApiClient>();
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            return services.BuildServiceProvider();
        }
    }
}

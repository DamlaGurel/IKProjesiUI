using Newtonsoft.Json;
using Refit;

namespace IKProjesi.UI.Extensions.HttpClientHandler
{
    public static class AddRefitService
    {
        public static IServiceCollection AddRefit<TRefitClient, THandler>(this IServiceCollection services, string configurationKey) where TRefitClient : class where THandler : DelegatingHandler
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddRefitClient<TRefitClient>(new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                })
            }).ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri(configurationKey))
               .AddHttpMessageHandler<THandler>();

            services.AddScoped<THandler>();

            return services;
        }
    }
}

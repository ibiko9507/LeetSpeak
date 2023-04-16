using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.DataAccess.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace UrlShortening.Api
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITranslateService, TranslateService>();
            services.AddScoped<ITranslateRepository, TranslateRepository>();
        }
    }
}

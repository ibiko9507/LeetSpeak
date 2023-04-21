using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Business.Services.Helpers.Factories;
using LeetSpeak.DataAccess.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace LeetSpeak.Api
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITranslateService, TranslateService>();
            services.AddScoped<ITranslateRepository, TranslateRepository>();
            services.AddScoped<ITranslationFactory, TranslationFactory>();
            services.AddScoped<TranslateValidator>();
        }
    }
}

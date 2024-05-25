using JobCandidate.Application.Manager.Implementation;
using JobCandidate.Application.Manager.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace JobCandidate.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IJobCandidateManager, JobCandidateManager>();
            return services;
        }
    }
}

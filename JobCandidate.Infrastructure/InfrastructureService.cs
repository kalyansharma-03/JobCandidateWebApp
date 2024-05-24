using JobCandidate.Infrastructure.Repository;
using JobCandidate.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobCandidate.Infrastructure
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobCandidateDBContext>(o => o.UseNpgsql(configuration["ConnectionStrings:DbContext"]), ServiceLifetime.Scoped);
            services.AddScoped<IJobCondidateService, JobCandidateService>();
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped(typeof(IServiceRepository<>), typeof(ServiceRepository<>));
            return services;
        }
    }
}

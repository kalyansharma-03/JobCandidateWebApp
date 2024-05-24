using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Infrastructure.Repository
{
    public class JobDBMigration
    {
        public static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = new JobCandidateDBContext(serviceScope.ServiceProvider.GetService<
                           DbContextOptions<JobCandidateDBContext>>()))
                {
                    context.Database.Migrate();
                }


            }
        }
    }
}

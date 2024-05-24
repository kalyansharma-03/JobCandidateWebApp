using JobCandidate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Infrastructure.Repository
{
    public class JobCandidateDBContext : DbContext
    {
        public JobCandidateDBContext() { }

        public JobCandidateDBContext(DbContextOptions<JobCandidateDBContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbContext");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        public DbSet<EJobCandidateDetails> JobCandidateDetails { get; set; }
    }
}

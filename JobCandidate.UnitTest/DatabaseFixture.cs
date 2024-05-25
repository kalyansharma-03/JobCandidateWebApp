using JobCandidate.Infrastructure;
using JobCandidate.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobCandidate.UnitTest.Data;

namespace JobCandidate.UnitTest
{
    public class DatabaseFixture : IDisposable
    {

        public JobCandidateDBContext DbContext { get; private set; }

        public DatabaseFixture()
        {
            // Create a new ServiceCollection
            var serviceCollection = new ServiceCollection();

            // Add the in-memory database provider
            serviceCollection.AddDbContext<JobCandidateDBContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Build the service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Create a new instance of the DbContext from the service provider
            DbContext = serviceProvider.GetRequiredService<JobCandidateDBContext>();

            #region
            JobCandidateDataInfo.Init();
            var candidateDetails = JobCandidateDataInfo.JobCandidateList;
            DbContext.JobCandidateDetails.AddRange(candidateDetails);
            #endregion

            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            // Dispose the DbContext when the tests are done
            DbContext.Dispose();
        }
    }
}

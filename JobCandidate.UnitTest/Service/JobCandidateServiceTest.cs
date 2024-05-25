using JobCandidate.Infrastructure.Repository;
using JobCandidate.Infrastructure.Service;
using JobCandidate.UnitTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JobCandidate.UnitTest.Service
{
    public class JobCandidateServiceTest : IClassFixture<DatabaseFixture>
    {
        [Fact]
        public async Task AddJobCandidateDetails_OnSuccess_ReturnsTrue()
        {
            DatabaseFixture _fixture = new DatabaseFixture();
            using(var factory = new ServiceFactory(_fixture.DbContext, true))
            {
                //arrange
                var service = new JobCandidateService(factory);

                var model = JobCandidateDataInfo.EJobCandidateDetails;
                model.Email = "test123@gmail.com";

                //act
                var result = await service.AddJobCandidateDetails(model);

                //assert
                Assert.True(result);
            }
        }
        [Fact]
        public async Task UpdateJobCandidateDetails_OnSuccess_ReturnsTrue()
        {
            DatabaseFixture _fixture = new DatabaseFixture();
            using (var factory = new ServiceFactory(_fixture.DbContext, true))
            {
                //arrange
                var service = new JobCandidateService(factory);

                var model = JobCandidateDataInfo.EJobCandidateDetails;

                //act
                var result = await service.UpdateJobCandidateDetails(model);

                //assert
                Assert.True(result);
            }
        }
        [Fact]
        public async Task IsEmailExists_OnExistingEmail_ReturnsModel()
        {
            DatabaseFixture _fixture = new DatabaseFixture();
            using (var factory = new ServiceFactory(_fixture.DbContext, true))
            {
                //arrange
                var service = new JobCandidateService(factory);

                var expected_result = JobCandidateDataInfo.EJobCandidateDetails;

                //act
                var result = await service.IsExistingEmail(expected_result.Email);

                //assert
                Assert.Equivalent(expected_result,result);
            }
        }
    }
}
